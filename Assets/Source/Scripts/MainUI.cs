
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
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

    private void OnCurrencyChanged(double value)
    {
        _goldValue.text = value.ToString();
    }
}
