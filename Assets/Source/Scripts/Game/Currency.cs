
using System;
using System.Data;
using UnityEngine;

public class Currency : Saveable
{
    public double Gold { get; private set; }

    public Currency(string id) : base(id) { }

    public void AddGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold += value;
    }

    public void SpendGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (CanSpendGold(value) == false)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold -= value;
    }

    public bool CanSpendGold(double value)
    {
        return Gold >= value;
    }

    protected override void ProcessSave()
    {
        CurrencyData currencyData = new()
        {
            Gold = Gold,
            SaveTime = DateTime.Now.ToString()
        };

        PlayerPrefs.SetString(ID, JsonUtility.ToJson(currencyData));
    }

    protected override void ProcessLoad()
    {
        if (PlayerPrefs.HasKey(ID) == false)
            return;

        CurrencyData saveData = JsonUtility.FromJson<CurrencyData>(PlayerPrefs.GetString(ID));

        Gold = saveData.Gold;

        if (DateTime.TryParse(saveData.SaveTime, out DateTime saveTime))
            ProcessOfflineEarnings(saveTime);
    }

    private void ProcessOfflineEarnings(DateTime saveTime)
    {
        TimeSpan timeSpan = DateTime.Now - saveTime;
        double offlineEarnings = timeSpan.Seconds * Inventory.GoldBonusPerSecond;
        Gold += offlineEarnings;
        Debug.Log($"offline earnings is {FormatNumsHelper.Format(offlineEarnings)}");
    }

    private struct CurrencyData
    {
        public double Gold;
        public string SaveTime;
    }
}
