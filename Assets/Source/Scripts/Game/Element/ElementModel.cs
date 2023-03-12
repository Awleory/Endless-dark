
using System;

public abstract class ElementModel
{
    public event Action Changed;
    public event Action<ElementModel> AvailableStatusChanged;

    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public double Price { get; protected set; }
    public int Level { get; protected set; }
    public bool Obtained { get; protected set; }
    public AvailableStatus AvailableStatus { get; private set; }

    private readonly double _startPrice;
    private readonly float _priceGrowMultiplier;

    public ElementModel(string title, string description = "", int level = 0, double startPrice = 0, float priceGrowMultiplier = 1, AvailableStatus availableStatus = AvailableStatus.Hidden)
    {
        Title = title;
        Description = description;
        Level = level;
        _startPrice = startPrice;
        _priceGrowMultiplier = priceGrowMultiplier;

        Update();
        SetAvailableStatus(availableStatus);

        Changed += OnChanged;
    }

    public ElementModel(ElementConfig elementConfig, AvailableStatus availableStatus = AvailableStatus.Hidden)
        : this(elementConfig.Title, elementConfig.Description, elementConfig.StartLevel, elementConfig.StartPrice,
              elementConfig.PriceGrowMultiplier, availableStatus)
    { }

    public bool CanBuy()
    {
        return Currency.CanSpendGold(Price);
    }

    public void TryBuy()
    {
        if (CanBuy())
        {
            Currency.SpendGold(Price);

            if (Obtained == false)
                ProcessObtainStatus(true);

            UpLevel();
        }
    }

    public void SetAvailableStatus(AvailableStatus status, bool sureInvoke = false)
    {
        if (AvailableStatus == status && sureInvoke == false)
            return;

        AvailableStatus = status;
        AvailableStatusChanged?.Invoke(this);
    }

    protected virtual void Update()
    {
        Price = _startPrice * Math.Pow(_priceGrowMultiplier, Level);
    }

    protected abstract void OnChanged();

    private void UpLevel(int count = 1)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        Level += count;
        Update();

        Changed?.Invoke();
    }

    private void ProcessObtainStatus(bool state)
    {
        Obtained = state;

        if (Obtained)
            SetAvailableStatus(AvailableStatus.Available, true);
        else
            SetAvailableStatus(AvailableStatus.Hidden, true);
    }
}

public enum AvailableStatus
{
    Hidden,
    Locked,
    Available
}