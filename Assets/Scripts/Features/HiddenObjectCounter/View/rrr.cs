using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class rrr : MonoBehaviour
{
    public Transform parent;
    public Transform parent1;
    public CompositeDisposable disposables;
    [Inject] private ObjectCounterService counterService;
    [Inject] private MessageBroker messageBroker;
    [Inject] private ObjectInteractionService interactionService;
    [Inject] private AnimationViewFactory animationViewFactory;
    private void Start()
    {
        animationViewFactory.LoadPrefab(parent1);
        counterService.SetupUIPanel(parent);
        disposables = new CompositeDisposable();
        messageBroker.Receive<MessageBase>()
            .Subscribe(msg => { 
                Debug.Log(" receiver:" + msg.Id);
            }).AddTo(disposables);
        interactionService.Start();
    }
}
