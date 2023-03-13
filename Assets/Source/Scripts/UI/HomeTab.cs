
using TMPro;
using UnityEngine;

public class HomeTab : TabUI
{
    [SerializeField] private TextMeshProUGUI _goldValue;
    [SerializeField] private TextMeshProUGUI _goldPerSecond;

    private void OnEnable()
    {
        CurrencyStatic.Changed += OnCurrencyChanged;
        UpdateText();
    }

    private void OnDisable()
    {
        CurrencyStatic.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        _goldValue.text = FormatNumsHelper.Format(CurrencyStatic.Gold);
        _goldPerSecond.text = FormatNumsHelper.Format(Inventory.GoldBonusPerSecond);
    }
}
