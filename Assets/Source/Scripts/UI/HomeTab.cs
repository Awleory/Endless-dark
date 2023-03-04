
using TMPro;
using UnityEngine;

public class HomeTab : TabUI
{
    [SerializeField] private TextMeshProUGUI _goldValue;
    [SerializeField] private TextMeshProUGUI _goldPerSecond;

    private void OnEnable()
    {
        Currency.Changed += OnCurrencyChanged;
        UpdateText();
    }

    private void OnDisable()
    {
        Currency.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _goldValue.text = FormatNumsHelper.Format(Currency.Gold);
        _goldPerSecond.text = FormatNumsHelper.Format(Inventory.GoldBonusPerSecond);
    }
}
