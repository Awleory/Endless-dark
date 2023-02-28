

using UnityEngine;

public class UpgradeGoods : MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    public string Title => _title;
    public string Description => _description;
}
