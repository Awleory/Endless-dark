
using System;
using System.Collections.Generic;
using UnityEngine;

public class ListMenu : TabUI
{
    [SerializeField] private List<ListMenuCell> _cells = new();
    [SerializeField] private ListMenuLine _listMenuLineTamplate;
    [SerializeField] private GameObject _container;

    private readonly List<ListMenuLine> _listMenuLines = new();

    private void Awake()
    {
        _cells.ForEach(cell => CreateLine(cell));
    }

    private void CreateLine(ListMenuCell listMenuCell)
    {
        ListMenuLine listMenuLine = Instantiate(_listMenuLineTamplate, _container.transform);
        listMenuLine.Initialize(listMenuCell);
        _listMenuLines.Add(listMenuLine);
    }
}

[Serializable]
public class ListMenuCell
{
    public UpgradeGoods Goods;
    public double Price;
}
