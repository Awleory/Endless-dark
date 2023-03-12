
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Shop<TElementModel> : TabUI where TElementModel : ElementModel
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private string _title;
    [SerializeField] private Transform _content;
    [SerializeField] private ListElementUI<TElementModel> _lineTemplate;
    [SerializeField] protected List<ElementConfig> _elementConfigs;

    protected List<ListElementUI<TElementModel>> _elementsUI = new();

    public virtual void Initialize()
    {
        if (_titleText != null)
            _titleText.text = _title;
    }

    public void AddLineElement(TElementModel elementModel)
    {
        ListElementUI<TElementModel> elementUI = Instantiate(_lineTemplate, _content);
        _elementsUI.Add(elementUI);
        elementUI.Initialize(elementModel);
    }

    public static AvailableStatus GetNextElementAvailableStatus(AvailableStatus currentStatus, bool elementObtained)
    {
        AvailableStatus nextStatus = AvailableStatus.Hidden;

        switch (currentStatus)
        {
            case AvailableStatus.Available:
                nextStatus = elementObtained ? AvailableStatus.Available : AvailableStatus.Locked;
                break;
            case AvailableStatus.Locked:
                nextStatus = AvailableStatus.Hidden;
                break;
            default:
                break;
        }

        return nextStatus;
    }

    public static AvailableStatus GetNextElementAvailableStatus(ElementModel elementModel)
    {
        return GetNextElementAvailableStatus(elementModel.AvailableStatus, elementModel.Obtained);
    }
}
