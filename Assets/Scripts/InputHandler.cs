using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler:MonoBehaviour, IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public Action<PointerEventData> OnDragAction;
    public Action<PointerEventData> OnEndDragAction;
    public bool PointerDown = false;
    public virtual void OnDrag(PointerEventData eventData)
    {
        OnDragAction?.Invoke(eventData);
    }
    public virtual void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragAction?.Invoke(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PointerDown = false;
    }
}
