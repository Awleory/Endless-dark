
using System;
using UnityEngine;

public static class SaveLoad
{
    public static event Action SavingStarted;
    public static event Action LoadingStarted;
    public static event Action SaveLoadIsOver;

    private static int _saveLoadObjectsInProgress = 0;

    public static void SaveGame()
    {
        SavingStarted?.Invoke();
    }

    public static void LoadGame()
    {
        LoadingStarted?.Invoke();
    }

    public static void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void IncSaveLoadObject()
    {
        _saveLoadObjectsInProgress++;
    }

    public static void DecSaveLoadObject()
    {
        _saveLoadObjectsInProgress--;
        if (_saveLoadObjectsInProgress == 0)
            SaveLoadIsOver?.Invoke();
    }
}
