
using System;
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
            Gold = Gold
        };

        PlayerPrefs.SetString(ID, JsonUtility.ToJson(currencyData));
    }

    protected override void ProcessLoad()
    {
        if (PlayerPrefs.HasKey(ID) == false)
            return;

        CurrencyData currencyData = JsonUtility.FromJson<CurrencyData>(PlayerPrefs.GetString(ID));

        Gold = currencyData.Gold;
    }

    private struct CurrencyData
    {
        public double Gold;
    }
}
