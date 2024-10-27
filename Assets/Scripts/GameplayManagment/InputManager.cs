using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Zenject;

public class InputManager: ITickable
{
    public Action<Vector3> ClickEvent;
    public Action<Vector3> ClickEndEvent;

    private bool _clickToUI = false;

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            var сheckUIInteraction = СheckUIInteraction();

            if (!_clickToUI && сheckUIInteraction)
            {
                _clickToUI = true;
                return;
            }
            ClickEvent?.Invoke(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_clickToUI)
            {
                _clickToUI = false;
                return;
            }
            ClickEndEvent?.Invoke(Input.mousePosition);
        }
    }

    private bool СheckUIInteraction()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        Debug.Log(results);
        
        foreach (var raycastResult in results)
        {
            if (raycastResult.gameObject.transform is RectTransform)
            {
                return true;
            } 
        }

        return false;
    }

    public void Tick()
    {
        CheckClick();
    }
}
