using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Action<Vector2> OnDragAction;
    [SerializeField] InputHandler _hitSlider;
    private void Update()
    {
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(0) && !_hitSlider.PointerDown)
            {
                OnDrag(touch.position);
            }
        }
#else
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject() && !_hitSlider.PointerDown)
            {
                OnDrag(Input.mousePosition);
            }
        }
#endif
    }
    public virtual void OnDrag(Vector2 touch)
    {
        OnDragAction?.Invoke(touch);
    }
}
