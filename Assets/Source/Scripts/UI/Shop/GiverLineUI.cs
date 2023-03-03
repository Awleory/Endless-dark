
using TMPro;
using UnityEngine;

public class GiverLineUI : ListLineStoreBoughtUI
{
    [SerializeField] private TextMeshProUGUI _giverInfo;

    private GiverPerPeriod _perPeriodGiver;

    protected override void OnEnable()
    {
        base.OnEnable();
        _perPeriodGiver.LevelUp += OnGiverLevelUp;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _perPeriodGiver.LevelUp -= OnGiverLevelUp;
    }

    public void Initialize(string title, string description, GiverPerPeriod perPeriodGiver)
    {
        Initialize(title, description);

        _perPeriodGiver = perPeriodGiver;
        UpdateText();

        _perPeriodGiver.LevelUp += OnGiverLevelUp;

        enabled = true;
    }

    protected override void OnBuyButtonClick()
    {
        _perPeriodGiver.TryBuy();
    }

    protected override void UpdateText()
    {
        _price.text = FormatNumsHelper.Format(_perPeriodGiver.Price);
        _level.text = FormatNumsHelper.Format(_perPeriodGiver.Level);
        _giverInfo.text = FormatNumsHelper.Format(_perPeriodGiver.Value);
    }

    private void OnGiverLevelUp()
    {
        UpdateText();
    }
}
