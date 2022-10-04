using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler{
    public Transform tf;
    public CanvasGroup cg;
    public CircleCollider2D col;
    public void Awake()
    {
        tf = this.transform;
        cg = this.GetComponent<CanvasGroup>();
        col = this.GetComponent<CircleCollider2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.alpha = 0.1f;
        cg.blocksRaycasts = false;
        col.enabled = false; // without this colider adjustment, onDrop does not trigger.
        // if menu is active, set it to false.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        col.enabled = true; // without this colider adjustment, onDrop does not trigger.
        //Collider[] colList = Physics.OverlapSphere(this.transform.position, this.transform.localScale.y);
        ////Collider2D[] collidingList = col.OverlapCollider(ContactFilter2D.NoFilter());
        //if (colList.Length == 1)
        //{
        //    Debug.Log("Should be attached to new slot.");
        //}
        //else
        //{
        //    Debug.Log("should NOT be attached.");
        //}
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // just display menu.
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        tf.position = eventData.pointerCurrentRaycast.worldPosition;
    }
}
