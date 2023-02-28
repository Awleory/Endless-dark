
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListMenuLine : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _buyButton;

    public event Action BuyButtonPerformed;

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
        _title.text = listmenuCell.Goods.Title;
        _description.text = listmenuCell.Goods.Description;
        _price.text = listmenuCell.Price.ToString();
    }

    private void OnBuyButtonClick()
    {
        BuyButtonPerformed?.Invoke();
    }
}
