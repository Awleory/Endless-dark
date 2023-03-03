
using TMPro;
using UnityEngine;

public abstract class ListElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    protected virtual void OnEnable() { }

    protected virtual void OnDisable() { }

    public virtual void Initialize(string title, string description)
    {
        _titleText.text = title;
        _descriptionText.text = description;
    }
}
