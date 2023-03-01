
using System;

public class Upgrade
{
    public event Action LevelUp;

    public int Level { get; private set; }
    public double Price { get; private set; }
    public double GoldBonusPerClick { get; private set; }
    public double GoldBonusPerSecond { get; private set; }

    private double _startPrice;
    private double _startGoldBonusPerSecond;
    private double _startGoldBonusPerClick;

    public void Initialize(ListMenuCell listMenuCell)
    {
        Initialize(listMenuCell.Goods.StartPrice, listMenuCell.Goods.StartGoldBonusPerSecond, listMenuCell.Goods.StartGoldBonusPerClick);
    }

    public void Initialize(double startPrice, double startGoldBonusPerSecond, double startGoldBonusPerClick)
    {
        _startPrice = startPrice;
        _startGoldBonusPerSecond = startGoldBonusPerSecond;
        _startGoldBonusPerClick = startGoldBonusPerClick;
        UpLevel();
    }

    public void UpLevel(int count = 1)
    {
        Level += count;
        Price = CalculatePrice();
        CalculateBonuses();
        LevelUp?.Invoke();
    }

    private double CalculatePrice()
    {
        return _startPrice + _startPrice / 10 * Level + Price * 0.01;
    }

    private void CalculateBonuses()
    {
        GoldBonusPerClick = _startGoldBonusPerSecond + _startGoldBonusPerSecond / 10 * Level + _startGoldBonusPerSecond * 0.01;
        GoldBonusPerSecond = _startGoldBonusPerClick + _startGoldBonusPerClick / 10 * Level + _startGoldBonusPerClick * 0.01;
    }
}
