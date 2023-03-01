
using UnityEngine;

public class UpgradeTemplate : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private double _startPrice;
    [SerializeField] private double _startGoldBonusPerSecond;
    [SerializeField] private double _startGoldBonusPerClick;

    public string Title => _title;
    public string Description => _description;
    public double StartPrice => _startPrice;
    public double StartGoldBonusPerSecond => _startGoldBonusPerSecond;
    public double StartGoldBonusPerClick => _startGoldBonusPerClick;
}
