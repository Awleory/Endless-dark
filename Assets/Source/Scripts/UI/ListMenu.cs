
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ListMenu : TabUI
{
    [SerializeField] private List<ListMenuCell> _cells = new();
    [SerializeField] private ListMenuLine _listMenuLineTamplate;
    [SerializeField] private GameObject _container;
    [SerializeField] private Inventory _inventory;

    private readonly List<ListMenuLine> _listMenuLines = new();

    private void Awake()
    {
        foreach (var cell in _cells)
        {
            var menuLine = CreateLine(cell);
            _inventory.AddUpgrade(menuLine.Upgrade);
        }
        _cells.ForEach(cell => CreateLine(cell));
    }

    private ListMenuLine CreateLine(ListMenuCell listMenuCell)
    {
        ListMenuLine listMenuLine = Instantiate(_listMenuLineTamplate, _container.transform);
        listMenuLine.Initialize(listMenuCell);
        _listMenuLines.Add(listMenuLine);
        return listMenuLine;    
    }
}

[Serializable]
public class ListMenuCell
{
    public UpgradeTemplate Goods;
}
