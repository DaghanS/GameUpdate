using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GearChooser : MonoBehaviour, IPointerDownHandler, IDropHandler
// click on one gear icon to get gear recommendations
{
    // I
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
    public void OnDrop(PointerEventData eventData) // VERY UNOPTIMIZED
    {
        Debug.Log("OnDrop");
        drag = eventData.pointerDrag.transform;
        if (eventData.pointerDrag != null)
        {
            
            if (ifParentInv(parSlot)) // inv to gear  // insert inventory item to gear. 
            {
                if (this.transform.childCount == 0) 
                {
                    Transform dragCopy = Instantiate(drag, this.transform);
                    dragCopy.position = this.transform.position;
                    // return drag back to its slots position.
                    drag.position = drag.parent.position;
                }
                else
                {
                    GameObject oldChild = this.transform.GetChild(0).gameObject;
                    Destroy(oldChild);
                    Transform dragCopy = Instantiate(drag, this.transform);
                    dragCopy.position = this.transform.position;
                    // return drag back to its slots position.
                    drag.position = drag.parent.position;
                }
            }
            else // gear to gear 
            {
                if(this.transform.childCount == 0) // 0
                {
                    drag.SetParent(this.transform); // if slots empty, you can put it there.
                    drag.position = GetComponent<Transform>().position;
                    // location in inventory fix !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }
                else // 1
                {
                    Transform thisChild = this.transform.GetChild(0);
                    thisChild.position = parSlot.position;
                    thisChild.SetParent(parSlot);
                    drag.SetParent(this.transform); // if slots empty, you can put it there.
                    drag.position = GetComponent<Transform>().position;
                }
            }
        }
    }
    public bool ifParentInv(Transform par) // returns true if dragged obj has an itemslot parent.
    {
        try
        {
            Component bin = par.GetComponent<ItemSlot>(); // error here cancels everything
        }
        catch (UnityException e)
        {
            return false; // expected NullReferenceException
        }
        return true; // if bin != null return true.
    }
}