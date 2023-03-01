
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private List<GameObject> _menuTabs = new();

    public void OnButtonClick()
    {
        HideMenuTabs();
    }

    private void HideMenuTabs()
    {
        _menuTabs. ForEach(tab => tab.gameObject.SetActive(false));
    }
}
