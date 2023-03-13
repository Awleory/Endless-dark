
using UnityEngine;

public class ElementConfig : MonoBehaviour
{
    [SerializeField] private string _id = "1";
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private double _startPrice;
    [SerializeField] private double _startValue;
    [SerializeField] private int _startLevel = 1;
    [SerializeField] private float _priceGrowMultiplier = 1;

    public string Id => _id;
    public string Title => _title;
    public string Description => _description;
    public double StartPrice => _startPrice;
    public double StartValue => _startValue;
    public int StartLevel => _startLevel;
    public float PriceGrowMultiplier => _priceGrowMultiplier;
}
