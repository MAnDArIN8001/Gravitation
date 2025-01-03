using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class InputManager: ITickable
{
    public Action<Vector3, List<RaycastResult>> ClickEvent;
    public Action<Vector3> ClickEndEvent;

    private bool _clickToUI = false;

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            var сheckUIInteraction = СheckUIInteraction(out var results);

            if (!_clickToUI && сheckUIInteraction)
            {
                _clickToUI = true;
                return;
            }
            ClickEvent?.Invoke(Input.mousePosition, results);
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

    private bool СheckUIInteraction(out List<RaycastResult> results)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

         results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);
        
        
        foreach (var raycastResult in results)
        {
            Debug.Log(raycastResult);
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
