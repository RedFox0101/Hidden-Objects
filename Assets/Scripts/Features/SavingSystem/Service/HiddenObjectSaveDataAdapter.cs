using System;
using UniRx;
using UnityEngine;

public class HiddenObjectSaveDataAdapter
{
    private LevelRepository _levelRepository;
    private CompositeDisposable _disposable;
    private MessageBroker _messageBroker;

    public HiddenObjectSaveDataAdapter(MessageBroker messageBroker, LevelRepository levelRepository)
    {
        _levelRepository= levelRepository;
        _disposable = new CompositeDisposable();
        _messageBroker = messageBroker;
    }

    public void Setup() => SubscribeToSavingMessages();

    private void SubscribeToSavingMessages()
    {
        _messageBroker.Receive<HiddenObjectMessage>()
           .Subscribe(msg =>
           {
               SendMessage(msg.MessageContainer);
           }).AddTo(_disposable);
    }

    private void SendMessage(HiddenObjectMessageContainer hiddenObjectMessageContainer)
    {
        Debug.Log("SendMessage Hidden");
        var json = JsonUtility.ToJson(new HiddenObjectSaveData() { IsActive = false });
        var message = new SavingMessage(null, json, hiddenObjectMessageContainer.HiddenObjectData.Key+_levelRepository.CurrentLevelConfig.name);
        _messageBroker.Publish(message);
    }
}

[Serializable]
public class HiddenObjectSaveData
{
    public bool IsActive { get; set; }
}

