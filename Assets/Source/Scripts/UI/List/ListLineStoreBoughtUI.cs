
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ListLineStoreBoughtUI : ListElement
{
    [SerializeField] protected TextMeshProUGUI _price;
    [SerializeField] protected TextMeshProUGUI _level;
    [SerializeField] private Button _buyButton;

    private Coroutine _checkBuyingAvailability = null;
    private WaitForSeconds _checkBuyingAvailabilityTimer = new(1);

    public override void Initialize(string title, string description)
    {
        base.Initialize(title, description);
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        _buyButton.onClick.AddListener(OnBuyButtonClick);

        CheckBuyindAvailability();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    protected abstract void UpdateText();

    protected virtual void OnBuyButtonClick()
    {
        CheckBuyindAvailability();
    }

    protected abstract bool CanBuy();

    private IEnumerator CheckAvailabilityCoroutine()
    {
        while (CanBuy() == false)
        {
            yield return _checkBuyingAvailabilityTimer;
        }

        _checkBuyingAvailability = null;
        CheckBuyindAvailability();
    }

    private void CheckBuyindAvailability()
    {
        if (CanBuy())
        {
            _buyButton.interactable = true;
        }
        else
        {
            _buyButton.interactable = false;

            if (_checkBuyingAvailability != null)
            {
                StopCoroutine(_checkBuyingAvailability);
                _checkBuyingAvailability = null;
            }
            _checkBuyingAvailability = StartCoroutine(CheckAvailabilityCoroutine());
        }
    }
}
