
using TMPro;
using UnityEngine;

public class GiverUI : ListElementUI<Giver>
{
    [SerializeField] private TextMeshProUGUI _goldBonus;

    protected override void UpdateText()
    {
        base.UpdateText();

        if (_elementModel.Obtained)
            _goldBonus.text = FormatNumsHelper.Format(_elementModel.GoldBonus);
        else
            _goldBonus.text = FormatNumsHelper.Format(_elementModel.StartGoldBonus);
    }
}
