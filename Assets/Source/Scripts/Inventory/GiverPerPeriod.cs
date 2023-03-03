
public class GiverPerPeriod : LevelUpable
{
    public double Value { get; private set; }

    private readonly double _startValue;

    public GiverPerPeriod(double startPrice, double startValue, int startLevel = 1) : base(startPrice, startLevel) 
    {
        _startValue = startValue;
    }

    protected override void Update()
    {
        base.Update();
        CalculateValue();
    }

    private void CalculateValue()
    {
        Value = _startValue + _startValue * (Level - 1);
    }
}
