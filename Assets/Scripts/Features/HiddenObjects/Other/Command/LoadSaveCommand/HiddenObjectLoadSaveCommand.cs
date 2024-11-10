using UnityEngine;

public class HiddenObjectLoadSaveCommand : ILoadSaveCommand
{
    private GameObject _gameObject;

    public HiddenObjectLoadSaveCommand(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public void LoadSave(string key, SavingService savingService)
    {
        if(savingService.TryLoadSaveData(key, out string json))
        {
            _gameObject.SetActive(false);
        }
    }
}
