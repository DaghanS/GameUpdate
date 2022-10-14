/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {
    Transform drag;
    Transform parSlot;
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
         drag = eventData.pointerDrag.transform;
         parSlot = drag.parent;
        if (eventData.pointerDrag != null)
        {
            if (ifParentInv(parSlot)) // if inv to inv (change location if 0 child //// swap locations of 2 gears if 1 child.) // switch item locations.
            {
                try
                {
                    this.transform.GetChild(0).position = parSlot.position;
                    this.transform.GetChild(0).SetParent(parSlot);
                }
                catch (UnityException e)
                {
                    // no children ??
                }
                drag.SetParent(this.transform);
                drag.position = this.transform.position;
                drag = setStats(drag);
                // location in inventory fix !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
            else // if gear to inv = destroy gear. // empty the gear slot.
            {
                // find equipped object and remove equipped. // this is VERY cursed.
                drag.GetComponent<GearStatus>().equipped.GetComponent<GearStatus>().ifEquipped = false;
                drag.GetComponent<GearStatus>().GetComponent<GearStatus>().equipped = null;
                Destroy(drag.gameObject);
            }
        }
    }
    public bool ifParentInv(Transform par)
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
