
using UnityEngine;

public class ElementConfig : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private double _startPrice;
    [SerializeField] private double _startValue;
    [SerializeField] private int _startLevel = 1;

    public string Title => _title;
    public string Description => _description;
    public double StartPrice => _startPrice;
    public double StartValue => _startValue;
    public int StartLevel => _startLevel;
}
