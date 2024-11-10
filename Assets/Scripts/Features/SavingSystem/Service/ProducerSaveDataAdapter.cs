using UniRx;
using UnityEngine;

public class ProducerSaveDataAdapter 
{
    private CompositeDisposable _disposable;
    private MessageBroker _messageBroker;
    private LevelRepository _levelRepository;
    public ProducerSaveDataAdapter(MessageBroker messageBroker, LevelRepository levelRepository)
    {
        _disposable = new CompositeDisposable();
        _messageBroker = messageBroker;
        _levelRepository = levelRepository;
    }

    public void Setup() => SubscribeToSavingMessages();

    private void SubscribeToSavingMessages()
    {
        _messageBroker.Receive<ProducerMessage>()
           .Subscribe(msg =>
           {
               SendMessage(msg);
           }).AddTo(_disposable);
    }

    private void SendMessage(ProducerMessage message)
    {
        var json = JsonUtility.ToJson(new ProducerData() 
        {
            IsBoxColliderEnable = false
        });

        Debug.Log("SendMessage Producer");
        var newMessage = new SavingMessage(null, json, message.HiddenObjectData.Key+ _levelRepository.CurrentLevelConfig.name);
        _messageBroker.Publish(newMessage);
    }
}

[SerializeField] 
public class ProducerData
{
    public bool IsBoxColliderEnable;
}