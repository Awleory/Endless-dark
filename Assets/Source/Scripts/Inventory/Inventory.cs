
using System.Collections.Generic;

public static class Inventory
{
    public static double GoldBonusPerClick { get; private set; } = 1;
    public static double GoldBonusPerSecond { get; private set; }

    private static readonly List<GiverPerPeriod> _perPeriodGivers = new();

    public static void AddGiver(GiverPerPeriod perPeriodGiver)
    {
        _perPeriodGivers.Add(perPeriodGiver);
        perPeriodGiver.LevelUp += OnUpgradeDone;

        CalculateBonus();
    }

    private static void CalculateBonus()
    {
        double bonusPerClick = 1;
        double bonusPerSecond = 0;

        foreach (var giver in _perPeriodGivers)
        {
            bonusPerSecond += giver.Value;
        }

        GoldBonusPerClick = bonusPerClick;
        GoldBonusPerSecond = bonusPerSecond;
    }

    private static void OnUpgradeDone()
    {
        CalculateBonus();
    }
}
