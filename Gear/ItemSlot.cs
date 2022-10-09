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
                if (this.transform.childCount == 0)
                {
                    drag.SetParent(this.transform); // if slots empty, you can put it there.
                    drag.position = GetComponent<Transform>().position;
                    // location in inventory fix !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                }
                else
                {
                    this.transform.GetChild(0).position = parSlot.position;
                    this.transform.GetChild(0).SetParent(parSlot);
                    drag.SetParent(this.transform);
                    drag.position = this.transform.position;
                }
            }
            else // if gear to inv = destroy gear. // empty the gear slot.
            {
                Destroy(drag.gameObject);
            }
        }
    }
    public bool ifParentInv(Transform par)
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
