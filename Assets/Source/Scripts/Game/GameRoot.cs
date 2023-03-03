
using System.Collections;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private readonly WaitForSeconds _oneSecond = new(1);

    private void Awake()
    {
        StartCoroutine(UpdateSecondCoroutine());
    }

    public void OnTheClickButtonClick()
    {
        Currency.AddGold(Inventory.GoldBonusPerClick);
    }

    private IEnumerator UpdateSecondCoroutine()
    {
        while (true)
        {
            yield return _oneSecond;
            UpdateSecond();
        }
    }

    private void UpdateSecond()
    {
        Currency.AddGold(Inventory.GoldBonusPerSecond);
    }
}
