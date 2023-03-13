
using System;

public static class CurrencyStatic
{
    public static event Action Changed;
    public static event Action GoldSpent;
    public static event Action GoldAdded;

    public static double Gold => _currency.Gold;

    private const string _currencyKey = "Currency";
    private static readonly Currency _currency = new(_currencyKey);

    public static void AddGold(double value)
    {
        _currency.AddGold(value);

        Changed?.Invoke();
        GoldAdded?.Invoke();
    }

    public static void SpendGold(double value)
    {
        _currency.SpendGold(value);

        Changed?.Invoke();
        GoldSpent?.Invoke();
    }

    public static bool CanSpendGold(double value)
    {
        return _currency.CanSpendGold(value);
    }
}
