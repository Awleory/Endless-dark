
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ListElementUI<TElemenModel> : MonoBehaviour where TElemenModel : ElementModel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Image _background;
    [SerializeField] private Button _buyButton;

    public TElemenModel ElementModel => _elementModel;
    public bool IsAvaliable => _elementModel != null && _elementModel.AvailableStatus == AvailableStatus.Available;

    protected TElemenModel _elementModel;

    private Color _originalBGColor;
    private Coroutine _checkBuyingAvailability = null;
    private readonly WaitForSeconds _checkBuyingAvailabilityTimer = new(1);
    private readonly Color _notAbailableColor = Color.gray;

    private void Awake()
    {
        _originalBGColor = _background.color;
    }

    private void OnEnable()
    {
        if (_elementModel != null)
        {
            _elementModel.Changed += OnElementalModelChanged;
            UpdateBuyButton();
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

    private void OnDestroy()
    {
        if (_elementModel != null)
            _elementModel.AvailableStatusChanged -= OnAvailableStatusChanged;
    }

    public void Initialize(TElemenModel elementModel)
    {
        _elementModel = elementModel;
        _elementModel.AvailableStatusChanged += OnAvailableStatusChanged;

        UpdateText();
        UpdateBuyButton();

        ProcessByAvialiableStatus(elementModel.AvailableStatus);

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

    protected void ProcessByAvialiableStatus(AvailableStatus status)
    {
        switch (status)
        {
            case AvailableStatus.Available:
                ProcessAvailableStatus();
                break;
            case AvailableStatus.Locked:
                ProcessLockStatus();
                break;
            case AvailableStatus.Hidden:
                ProcessHiddenStatus();
                break;
        }
    }

    private void ProcessAvailableStatus()
    {
        StateLockStatus(false);

        _background.color = _originalBGColor;

        UpdateText();
        UpdateBuyButton();

        gameObject.SetActive(true);
    }

    private void ProcessLockStatus()
    {
        StateLockStatus(true);

        if (_titleText != null) _titleText.text = "???";

        _background.color = _notAbailableColor;

        gameObject.SetActive(true);
    }

    private void ProcessHiddenStatus()
    {
        gameObject.SetActive(false);
    }

    private void StateLockStatus(bool state)
    {
        bool lockState = state == false;

        if (_description != null) _description.enabled = lockState;
        if (_price != null) _price.enabled = lockState;
        if (_level != null) _level.enabled = lockState;
        if (_buyButton != null) _buyButton.interactable = lockState;
    }

    private void UpdateBuyButton()
    {
        if (IsAvaliable == false)
            return;

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
        UpdateBuyButton();
    }

    private void SetValue(ref object value, object newValue)
    {
        if (value == null)
            return;

        value = newValue;
    }

    private void OnBuyButtonClick()
    {
        _elementModel.TryBuy();
        UpdateBuyButton();
    }

    private void OnElementalModelChanged()
    {
        if (IsAvaliable == false)
            return;

        UpdateText();
    }

    private void OnAvailableStatusChanged(ElementModel elementModel)
    {
        ProcessByAvialiableStatus(elementModel.AvailableStatus);
    }
}
