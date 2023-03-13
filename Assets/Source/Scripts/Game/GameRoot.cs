
using System.Collections;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    [SerializeField] private GiverShop _giverShop;
    [SerializeField] private bool _resetSave;

    private readonly WaitForSeconds _oneSecond = new(1);

    private void Awake()
    {
        _giverShop.Initialize();
    }

    private void Start()
    {
        if (_resetSave)
            SaveLoad.ResetSave();

        SaveLoad.LoadGame();

        StartCoroutine(UpdateSecondCoroutine());
    }

    public void OnTheClickButtonClick()
    {
        CurrencyStatic.AddGold(Inventory.GoldBonusPerClick);
    }

    private IEnumerator UpdateSecondCoroutine()
    {
        while (true)
        {
            UpdateSecond();
            yield return _oneSecond;
        }
    }

    private void UpdateSecond()
    {
        CurrencyStatic.AddGold(Inventory.GoldBonusPerSecond);
    }

    private void OnApplicationQuit()
    {
        SaveLoad.SaveGame();
    }
}
