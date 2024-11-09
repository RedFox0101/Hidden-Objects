using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelObjec : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [Inject] private ObjectInitializeService objectInitializer;

    private void Start()
    {
        objectInitializer.InitializeObjects(_parent);
    }
}
