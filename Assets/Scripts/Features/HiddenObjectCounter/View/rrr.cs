using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class rrr : MonoBehaviour
{
    public Transform parent;
    public CompositeDisposable disposables;
    [Inject] private ObjectCounterService counterService;
    [Inject] private MessageBroker messageBroker;
    [Inject] private ObjectInteractionService interactionService;
    private void Start()
    {
        counterService.SetupUIPanel(parent);
        disposables = new CompositeDisposable();
        messageBroker.Receive<MessageBase>()
            .Subscribe(msg => { 
                Debug.Log(" receiver:" + msg.id);
            }).AddTo(disposables);
        interactionService.Start();
    }
}
