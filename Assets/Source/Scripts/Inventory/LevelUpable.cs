
using System;

public abstract class LevelUpable
{
    public event Action LevelUp;

    public int Level { get; private set; }
    public double Price { get; private set; }

    private readonly double _startPrice;

    public LevelUpable(double startPrice, int startLevel = 1)
    {
        _startPrice = startPrice;
        Level = startLevel;

        Update();
    }

    public bool CanBuy()
    {
        return Currency.CanSpendGold(Price);
    }

    public void TryBuy()
    {
        if (CanBuy())
        {
            Currency.SpendGold(Price);
            UpLevel();
        }
    }

    public void UpLevel(int count = 1)
    {
        Level += count;
        Update();
        LevelUp?.Invoke();
    }

    protected virtual void Update()
    {
        CalculatePrice();
    }

    private void CalculatePrice()
    {
        Price += _startPrice + _startPrice / 10 * Level + Price * 0.7;
    }
}
