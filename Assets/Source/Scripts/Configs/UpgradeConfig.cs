
using UnityEngine;

public class UpgradeConfig : EntityConfig
{
    [SerializeField] private double _startPrice;
    [SerializeField] private double _startGoldBonus;
    [SerializeField] private int _startLevel = 1;

    public double StartPrice => _startPrice;
    public double StartGoldBonus => _startGoldBonus;
    public int StartLevel => _startLevel;
}
