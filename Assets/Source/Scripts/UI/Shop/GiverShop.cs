
using System.Collections.Generic;
using UnityEngine;

public class GiverShop : TabUI
{
    [SerializeField] private List<UpgradeConfig> _upgradeConfigs;
    [SerializeField] private GiverLineUI _giverLineTemplate;
    [SerializeField] private Transform _content;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        foreach (var upgrade in _upgradeConfigs)
        {
            GiverLineUI element = Instantiate(_giverLineTemplate, _content);
            GiverPerPeriod giver = new GiverPerPeriod(upgrade.StartPrice, upgrade.StartGoldBonus, upgrade.StartLevel);
            element.Initialize(upgrade.Title, upgrade.Description, giver);

            Inventory.AddGiver(giver);
        }
    }
}
