using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GearChooser : MonoBehaviour, IPointerDownHandler, IDropHandler
// click on one gear icon to get gear recommendations
{
    Transform drag;
    Transform parSlot;
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
        drag = eventData.pointerDrag.transform;
        if (eventData.pointerDrag != null)
        {
            if (ifParentInv(parSlot)) // inv to gear
            {
                if (this.transform.childCount == 0) 
                {
                    GameObject oldChild = this.transform.GetChild(0).gameObject;
                    Destroy(oldChild);
                    Transform dragCopy = Instantiate(drag, this.transform);
                    dragCopy.position = this.transform.position;
                }
                else
                {
                    
                }
            }
            else // gear to gear
            {
                // swap if 0 or 1 child
            }
        }
    }
    public bool ifParentInv(Transform par)
    {
        Component bin = par.GetComponent<ItemSlot>();
        if (bin != null) return true;
        return false;
    }
}