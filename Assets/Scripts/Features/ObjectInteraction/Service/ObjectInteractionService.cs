using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ObjectInteractionService
{
    private Camera _camera;
    public void Start()
    {
        _camera = Camera.main;
        Observable.EveryUpdate().Subscribe(_ => RaycastFromCamera());
    }

    public void RaycastFromCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("RaycastFromCamera");
            Vector2 screenPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(screenPosition, Vector2.zero);

            if (hit.collider != null)
            {

                BaseObjectView component = hit.collider.GetComponent<BaseObjectView>();
                if (component != null)
                {
                    component.OnClickedObject();
                }
            }
        }
    }
}
