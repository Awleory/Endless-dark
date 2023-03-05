
using TMPro;
using UnityEngine;

public class GiverUI : ListElementUI<Giver>
{
    [SerializeField] private TextMeshProUGUI _goldBonus;

    protected override void UpdateText()
    {
        base.UpdateText();
        _goldBonus.text = FormatNumsHelper.Format(_elementModel.GoldBonus);
    }
}
