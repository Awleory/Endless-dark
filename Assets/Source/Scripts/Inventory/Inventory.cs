
using System.Collections.Generic;

public static class Inventory
{
    public static double GoldBonusPerClick { get; private set; } = 1000;
    public static double GoldBonusPerSecond { get; private set; }
    public static double GiversGoldBonus { get; private set; }

    private static readonly List<Giver> _givers = new();

    public static void AddGiver(Giver giver)
    {
        _givers.Add(giver);
    }

    public static void RemoveGiver(Giver giver)
    {
        if (_givers.Contains(giver))
            _givers.Remove(giver);
    }

    public static void CalculateGiversBonus()
    {
        double bonusPerSecond = 0;

        foreach (var giver in _givers)
        {
            bonusPerSecond += giver.GoldBonus;
        }

        GiversGoldBonus = bonusPerSecond;

        CalculateBonus();
    }

    private static void CalculateBonus()
    {
        GoldBonusPerSecond = GiversGoldBonus;
    }
}
