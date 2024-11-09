using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class rrr : MonoBehaviour
{
    public Transform parent;
    [Inject] private ObjectCounterService counterService;

    private void Start()
    {
        counterService.SetupUIPanel(parent);
    }
}
