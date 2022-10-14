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
        parSlot = drag.parent;
        if (eventData.pointerDrag != null)
        {
            if (ifParentInv(parSlot)) // inv to gear  // insert inventory item to gear. 
            {
                if (!drag.GetComponent<GearStatus>().ifEquipped)
                {
                    drag.GetComponent<GearStatus>().ifEquipped = true;
                    try
                    {
                        GameObject oldChild = this.transform.GetChild(0).gameObject; // check for errors
                        oldChild.GetComponent<GearStatus>().equipped.GetComponent<GearStatus>().ifEquipped = false;
                        oldChild.GetComponent<GearStatus>().equipped.GetComponent<GearStatus>().equipped = null;
                        // find equipped object and remove equipped.
                        Destroy(oldChild);
                    }
                    catch(UnityException e)
                    {
                        // no children ??
                    }
                    drag = setStats(drag);
                    Transform dragCopy = Instantiate(drag, this.transform);

                    drag.GetComponent<GearStatus>().equipped = dragCopy.gameObject;
                    dragCopy.GetComponent<GearStatus>().equipped = drag.gameObject;
                    dragCopy.position = this.transform.position;

                    // return drag back to its slots position.
                    drag.position = drag.parent.position;
                }
                    
            }
            else // gear to gear 
            {
                try
                {
                    GameObject oldChild = this.transform.GetChild(0).gameObject; // check for errors
                    oldChild.transform.parent = drag.parent;
                    oldChild.transform.position = oldChild.transform.parent.position;
                }
                catch (UnityException e)
                {
                    // no children ??
                }
                drag = setStats(drag);
                drag.parent = this.transform;
                // return drag back to its slots position.
                drag.position = drag.parent.position;
            }
        }
    }
    public bool ifParentInv(Transform par) // returns true if dragged obj has an itemslot parent.
    {
        Component bin;
        try
        {
            bin = par.GetComponent<ItemSlot>(); // error here cancels everything
        }
        catch (UnityException e)
        {
            return false; // expected NullReferenceException
        }
        if (bin != null)return true; // if bin != null return true.
        return false; // else false.
    }
    public Transform setStats(Transform drag)
    {
        DragDrop stats = drag.GetComponent<DragDrop>();
        stats.col.enabled = true; // without this colider adjustment, onDrop does not trigger.
        stats.cg.blocksRaycasts = true;

        Component[] RenderLists = drag.GetComponentsInChildren<SpriteRenderer>();
        Color transparencyOpt = new Color(1, 1, 1, 1);
        foreach (SpriteRenderer objColor in RenderLists) objColor.color = transparencyOpt;

        return drag;
    }
}