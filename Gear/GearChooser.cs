using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GearChooser : MonoBehaviour, IPointerDownHandler, IDropHandler
// click on one gear icon to get gear recommendations
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDownGearSlot");
        
        // when clicked, give a que that player should choose another gear to select for this slot.
        // enable switching gear.
        // give visual que
        
        // enable an event?
        // when another gear is clicked unsub from event?

        // or just switch this to gear objects so they can be moved into other slots? seems like a better way 

        // drag drop handler needed
        // on dragbegin: clone the gear at the same hierarchy, decrease transparency of current gear.
        // on drag: move
        // on dragend: if not in a correct place destroy. if is in a slot increase transparency and trigger slot fitting.
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        Transform drag = eventData.pointerDrag.transform;
        if (eventData.pointerDrag != null)
        {
            if (this.transform.childCount == 0)
            {
                drag.SetParent(this.transform); // if slots empty, you can put it there.
                drag.position = GetComponent<Transform>().position;
            }
            else
            {
                GameObject oldChild = this.transform.GetChild(0).gameObject;
                Destroy(oldChild);
                Transform dragCopy = Instantiate(drag, this.transform);
                dragCopy.position = this.transform.position;
            }
        }
    }
}