
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListLineStoreBoughtUI : ListElement
{
    [SerializeField] protected TextMeshProUGUI _price;
    [SerializeField] protected TextMeshProUGUI _level;
    [SerializeField] private Button _buyButton;

    public override void Initialize(string title, string description)
    {
        base.Initialize(title, description);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    protected abstract void UpdateText();

    protected abstract void OnBuyButtonClick();
}
