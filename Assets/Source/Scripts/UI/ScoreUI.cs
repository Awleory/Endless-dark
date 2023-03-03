
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldValue;

    private void OnEnable()
    {
        Currency.Changed += OnCurrencyChanged;
    }

    private void OnDisable()
    {
        Currency.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged()
    {
        _goldValue.text = FormatNumsHelper.Format(Currency.Gold);
    }
}
