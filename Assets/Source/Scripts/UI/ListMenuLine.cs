
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListMenuLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Button _buyButton;

    public event Action BuyButtonPerformed;

    public Upgrade Upgrade => _upgrade;

    private Upgrade _upgrade;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    public void Initialize(ListMenuCell listmenuCell)
    {
        _upgrade = new();
        _upgrade.Initialize(listmenuCell);

        _title.text = listmenuCell.Goods.Title;
        _description.text = listmenuCell.Goods.Description;
        _price.text = _upgrade.Price.ToString();
        _level.text = _upgrade.Level.ToString();
    }

    private void OnBuyButtonClick()
    {
        BuyButtonPerformed?.Invoke();
    }
}
