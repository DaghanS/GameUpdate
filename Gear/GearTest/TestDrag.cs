using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler{
    public Transform tf;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Test Drag Begin works.");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Test Drag End works.");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Test Pointer Down");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        tf.position = eventData.pointerCurrentRaycast.worldPosition;
    }
}
