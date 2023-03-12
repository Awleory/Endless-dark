
public class GiverShop : Shop<Giver>
{
    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        AvailableStatus nextStatus = AvailableStatus.Available;
        Giver prevoiusGiver = null;
        for (int i = 0; i < _elementConfigs.Count; i++)
        {
            Giver giver = new(_elementConfigs[i], nextStatus, prevoiusGiver);
            prevoiusGiver = giver;
            nextStatus = GetNextElementAvailableStatus(giver);

            AddLineElement(giver);
        }
    }
}
