
using System;
using System.Collections;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    public event Action Changed;

    public double Gold { get; private set; }
    public double GoldPerSecond { get; private set; } = 1;
    public double GoldPerClick { get; private set; } = 1;

    private readonly WaitForSeconds _oneSecond = new(1);

    private void Awake()
    {
        StartCoroutine(UpdateEverySecond());
    }

    public void OnClickTheMainButton()
    {
        AddGold(GoldPerClick);
    }

    public void AddGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold += value;

        Changed?.Invoke();
    }

    public bool TrySpendGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (CanSpendGold(value) == false)
        {
            return false;
        }
        else
        {
            Gold -= value;
            Changed?.Invoke();
            return true;
        }
    }

    public bool CanSpendGold(double value)
    {
        return Gold >= value;
    }

    private void CalculateGoldPerClick()
    {
        GoldPerClick = 1;
    }

    private void CalculateGoldPerSecond()
    {
        GoldPerSecond = 1;
    }

    private void UpdateGold()
    {
        Gold += GoldPerSecond;
        Changed?.Invoke();
    }

    private IEnumerator UpdateEverySecond()
    {
        while (true)
        {
            yield return _oneSecond;
            UpdateGold();
        }
    }
}
