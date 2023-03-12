
public class Giver : ElementModel
{
    public double GoldBonus { get; private set; }

    private readonly double _startGoldBonus;
    private const string _description = "";
    private readonly Giver _previousGiver;

    public Giver(string title, double startGoldBonus, int startLevel, double startPrice, float priceGrowMultiplier,
        AvailableStatus availableStatus, Giver previousGiver = null) 
        : base(title, _description, startLevel, startPrice, priceGrowMultiplier, availableStatus)
    {
        _startGoldBonus = startGoldBonus;
        Update();

        Inventory.AddGiver(this);

        if (previousGiver != null)
        {
            _previousGiver = previousGiver;
            _previousGiver.AvailableStatusChanged += OnPreviousGiverStatusChanged;
        }
    }

    public Giver(ElementConfig elementConfig, AvailableStatus availableStatus, Giver previousGiver = null)
        : this(elementConfig.Title, elementConfig.StartValue, elementConfig.StartLevel, elementConfig.StartPrice,
              elementConfig.PriceGrowMultiplier, availableStatus, previousGiver)
    { }

    ~Giver()
    {
        Inventory.RemoveGiver(this);
        _previousGiver.AvailableStatusChanged -= OnPreviousGiverStatusChanged;
    }

    protected override void Update()
    {
        base.Update();
        GoldBonus = Level * _startGoldBonus;
    }

    protected override void OnChanged()
    {
        Inventory.CalculateGiversBonus();
    }

    private void OnPreviousGiverStatusChanged(ElementModel elementModel)
    {
        SetAvailableStatus(GiverShop.GetNextElementAvailableStatus(elementModel));
    }
}
