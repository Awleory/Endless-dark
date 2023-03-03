
using System;
using System.Linq;

public static class FormatNumsHelper
{
    private static readonly string[] _prefixes = new[]
    {
        "", "K", "M", "B", "T"
    };

    public static string Format(double value)
    {
        if (value == 0)
            return "0";

        value = Math.Round(value);

        int prefixIndex = 0;
        while (prefixIndex + 1 < _prefixes.Length && value >= 1000d)
        {
            value /= 1000d;
            prefixIndex++;
        }

        return value.ToString("#.##") + _prefixes[prefixIndex];
    }
}
