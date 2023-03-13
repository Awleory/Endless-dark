
public class Giver : ElementModel
{
    public double GoldBonus { get; private set; }
    public double StartGoldBonus => _startGoldBonus;

    private readonly double _startGoldBonus;
    private const string _description = "";
    private readonly Giver _previousGiver;

    public Giver(string id, string title, double startGoldBonus, int startLevel, double startPrice, float priceGrowMultiplier,
        AvailableStatus availableStatus, Giver previousGiver = null) 
        : base(id, title, _description, startLevel, startPrice, priceGrowMultiplier, availableStatus)
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
        : this(elementConfig.Id, elementConfig.Title, elementConfig.StartValue, elementConfig.StartLevel, elementConfig.StartPrice,
              elementConfig.PriceGrowMultiplier, availableStatus, previousGiver)
    { }

    ~Giver()
    {
        Inventory.RemoveGiver(this);

        if (_previousGiver != null)
            _previousGiver.AvailableStatusChanged -= OnPreviousGiverStatusChanged;
    }

    protected override void Update()
    {
        base.Update();
        GoldBonus = Level * _startGoldBonus;
    }

    protected override void ProcessLoad()
    {
        base.ProcessLoad();

        if (_previousGiver != null)
            SetAvailableStatus(Shop<ElementModel>.GetNextElementAvailableStatus(_previousGiver));
        else
            SetAvailableStatus(AvailableStatus.Available);
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
