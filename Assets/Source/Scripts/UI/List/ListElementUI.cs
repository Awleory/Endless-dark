
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ListElementUI<TElemenModel> : MonoBehaviour where TElemenModel : ElementModel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Button _buyButton;

    protected TElemenModel _elementModel;

    private Coroutine _checkBuyingAvailability = null;
    private readonly WaitForSeconds _checkBuyingAvailabilityTimer = new(1);

    private void OnEnable()
    {
        if (_elementModel != null)
        {
            _elementModel.Changed += OnElementalModelChanged;
            UpdateBuyStatus();
        }

        if (_buyButton != null)
            _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        if (_elementModel != null)
            _elementModel.Changed -= OnElementalModelChanged;

        if (_buyButton != null)
            _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    public void Initialize(TElemenModel elementModel)
    {
        _elementModel = elementModel;

        UpdateText();
        UpdateBuyStatus();

        enabled = true;
    }

    protected virtual void UpdateText()
    {
        if (_titleText != null)
            _titleText.text = _elementModel.Title;
        if (_description != null)
            _description.text = _elementModel.Description;
        if (_price != null)
            _price.text = FormatNumsHelper.Format(_elementModel.Price);
        if (_level != null)
            _level.text = FormatNumsHelper.Format(_elementModel.Level);
    }

    private void OnBuyButtonClick()
    {
        _elementModel.TryBuy();
        UpdateBuyStatus();
    }

    private void UpdateBuyStatus()
    {
        if (_buyButton == null)
            return;

        if (_elementModel.CanBuy())
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
            _checkBuyingAvailability = StartCoroutine(BuyStatusCoroutine());
        }
    }

    private IEnumerator BuyStatusCoroutine()
    {
        while (_elementModel.CanBuy() == false)
        {
            yield return _checkBuyingAvailabilityTimer;
        }

        _checkBuyingAvailability = null;
        UpdateBuyStatus();
    }

    private void OnElementalModelChanged()
    {
        UpdateText();
    }
}
