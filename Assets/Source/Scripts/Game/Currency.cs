
using System;

public static class Currency
{
    public static event Action Changed;

    public static double Gold { get; private set; } = 80000;

    public static void AddGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold += value;

        Changed?.Invoke();
    }

    public static void SpendGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (CanSpendGold(value) == false)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold -= value;
        Changed?.Invoke();
    }

    public static bool CanSpendGold(double value)
    {
        return Gold >= value;
    }
}
