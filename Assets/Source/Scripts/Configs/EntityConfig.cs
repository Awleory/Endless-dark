
using UnityEngine;

public abstract class EntityConfig: MonoBehaviour
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    public string Title => _title;
    public string Description => _description;
}
