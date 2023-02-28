
using System;

public static class Currency
{
    public static event Action<double> Changed;

    public static double Gold { get; private set; }

    public static void AddGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold += value;

        Changed?.Invoke(Gold);
    }

    public static void AddGold(float value)
    {
        AddGold((double)value);
    }

    public static void RemoveGold(double value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        if (Gold < value)
            throw new ArgumentOutOfRangeException(nameof(value));

        Gold -= value;

        Changed?.Invoke(Gold);
    }
}
