
public class Giver : ElementModel
{
    public double GoldBonus { get; private set; }

    private readonly double _startGoldBonus;
    private const float _priceGrowMultiplier = 1.07f;
    private const string _description = "";

    public Giver(string title, double startGoldBonus, int startLevel = 1, double startPrice = 0) : base(title, _description, startLevel, startPrice, _priceGrowMultiplier)
    {
        _startGoldBonus = startGoldBonus;
    }

    public Giver(ElementConfig elementConfig) : base(elementConfig.Title, _description, elementConfig.StartLevel, elementConfig.StartPrice, _priceGrowMultiplier)
    {
        _startGoldBonus = elementConfig.StartValue;
    }

    protected override void Update()
    {
        base.Update();
        GoldBonus = Level * _startGoldBonus;
    }
}
