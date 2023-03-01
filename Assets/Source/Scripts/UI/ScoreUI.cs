
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Currency _currency;
    [SerializeField] private TextMeshProUGUI _goldValue;

    private void OnEnable()
    {
        _currency.Changed += OnCurrencyChanged;
    }

    private void OnDisable()
    {
        _currency.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged()
    {
        _goldValue.text = _currency.Gold.ToString();
    }
}
