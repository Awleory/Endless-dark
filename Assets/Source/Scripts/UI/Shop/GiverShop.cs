
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiverShop : TabUI
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private string _title;
    [SerializeField] private List<ElementConfig> _elementConfigs;
    [SerializeField] private ListElementUI<Giver> _lineTemplate;
    [SerializeField] private Transform _content;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (_titleText != null)
            _titleText.text = _title;

        foreach (var elementConfig in _elementConfigs)
        {
            ListElementUI<Giver> element = Instantiate(_lineTemplate, _content);
            Giver giver = new(elementConfig);
            element.Initialize(giver);
            Inventory.AddGiver(giver);
        }
    }
}
