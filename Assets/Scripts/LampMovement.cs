using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class LampMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas myCanvas;
    [SerializeField] private bool canMove = false;
    private Vector3 _initialPosition;
    private Vector3 _initialScale;
    [SerializeField] private float lampScale = 2f;
    private Vector3 _lampZoomedScale;
    
    private void Start()
    {
        _initialPosition = transform.position;
        _initialScale = transform.localScale;
        _lampZoomedScale = transform.localScale * lampScale;
    }

    public void ToggleLampMovement()
    {
        canMove = !canMove;
    }


    public void OnBeginDrag(PointerEventData eventdata)
    {
        if (!canMove) return;

        transform.localScale = _lampZoomedScale;
    }
    
    public void OnDrag(PointerEventData eventdata) // Perfect for Dragging
    {
        if (!canMove) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out var pos);
        pos.y -= 200f;
        transform.position = myCanvas.transform.TransformPoint(pos);
    }

    public void OnEndDrag(PointerEventData eventdata)
    {
        if (!canMove) return;
        
        transform.position = _initialPosition;
        transform.localScale = _initialScale;
    }
}
