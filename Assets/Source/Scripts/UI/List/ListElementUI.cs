
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListElementUI<TElemenModel> : MonoBehaviour where TElemenModel : ElementModel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Image _background;
    [SerializeField] private Button _buyButton;

    public TElemenModel ElementModel => _elementModel;
    public bool IsAvaliable => _elementModel != null && _elementModel.AvailableStatus == AvailableStatus.Available && _enabled;

    protected TElemenModel _elementModel;

    private bool _enabled = false;
    private Color _originalBGColor;
    private readonly Color _notAbailableColor = Color.gray;

    private void OnEnable()
    {
        _enabled = true;

        if (_elementModel != null)
        {
            _elementModel.Changed += OnElementalModelChanged;
            UpdateBuyButton();
        }

        if (_buyButton != null)
            _buyButton.onClick.AddListener(OnBuyButtonClick);

        CurrencyStatic.GoldAdded += OnGoldAdded;
        CurrencyStatic.GoldSpent += OnGoldSpent;
    }

    private void OnDisable()
    {
        _enabled = false;

        if (_elementModel != null)
            _elementModel.Changed -= OnElementalModelChanged;

        if (_buyButton != null)
            _buyButton.onClick.RemoveListener(OnBuyButtonClick);

        CurrencyStatic.GoldAdded -= OnGoldAdded;
        CurrencyStatic.GoldSpent -= OnGoldSpent;
    }

    private void OnDestroy()
    {
        if (_elementModel != null)
            _elementModel.AvailableStatusChanged -= OnAvailableStatusChanged;
    }

    public void Initialize(TElemenModel elementModel)
    {
        _originalBGColor = _background.color;

        _elementModel = elementModel;
        _elementModel.Changed += OnElementalModelChanged;
        _elementModel.AvailableStatusChanged += OnAvailableStatusChanged;

        UpdateText();
        UpdateBuyButton();

        ProcessByAvialiableStatus(elementModel.AvailableStatus);
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
        if (_buyButton != null) _buyButton.gameObject.SetActive(lockState);
    }

    private void UpdateBuyButton(bool goldAdded = true)
    {
        if (_buyButton == null || IsAvaliable == false)
            return;

        if (_buyButton.interactable != goldAdded)
        {
            _buyButton.interactable = _elementModel.CanBuy();
        }
    }

    private void OnBuyButtonClick()
    {
        _elementModel.TryBuy();
        UpdateBuyButton(false);
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

    private void OnGoldAdded()
    {
        UpdateBuyButton(true);
    }

    private void OnGoldSpent()
    {
        UpdateBuyButton(false);
    }
}
