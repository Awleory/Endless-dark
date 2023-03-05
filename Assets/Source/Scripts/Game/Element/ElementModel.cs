
using System;

public abstract class ElementModel
{
    public event Action Changed;

    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public double Price { get; protected set; }
    public int Level { get; protected set; }

    private readonly double _startPrice;
    private readonly float _priceGrowMultiplier;

    public ElementModel(string title, string description = "", int level = 1, double startPrice = 0, float priceGrowMultiplier = 1)
    {
        Title = title;
        Description = description;
        Level = level;
        _startPrice = startPrice;
        _priceGrowMultiplier = priceGrowMultiplier;

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

    protected virtual void Update()
    {
        Price += _startPrice * Math.Pow(_priceGrowMultiplier, Level - 1);
    }

    private void UpLevel(int count = 1)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Level += count;
        Update();

        Changed?.Invoke();
    }
}
