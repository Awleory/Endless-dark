
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void OnMainButtonClicked()
    {
        Currency.AddGold(Bonuses.GoldPerClick);
    }
}
