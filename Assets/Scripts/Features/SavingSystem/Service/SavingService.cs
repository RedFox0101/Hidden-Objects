using UniRx;
using UnityEngine;

public class SavingService
{
    private CompositeDisposable _disposables;
    private MessageBroker _messageBroker;

    public SavingService(MessageBroker messageBroker)
    {
        _disposables = new CompositeDisposable();
        _messageBroker = messageBroker;
        SubscribeToSavingMessages();
    }

    public bool TryLoadSaveData(string key, out string jsonData)
    {
        jsonData = null;
        if (!PlayerPrefs.HasKey(key))
            return false;

        jsonData = PlayerPrefs.GetString(key);
        return true;
    }

    public void SaveData(string jsonData, string key)
    {
        PlayerPrefs.SetString(key, jsonData);
        PlayerPrefs.Save();
    }

    private void SubscribeToSavingMessages()
    {
        _messageBroker.Receive<SavingMessage>()
           .Subscribe(msg =>
           {
               SaveData(msg.JsonData, msg.Key);
           }).AddTo(_disposables);
    }
}
