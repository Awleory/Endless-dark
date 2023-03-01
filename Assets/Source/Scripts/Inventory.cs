using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private readonly List<Upgrade> _upgrades = new();

    public void AddUpgrade(Upgrade upgrade)
    {
        _upgrades.Add(upgrade);
    }
}
