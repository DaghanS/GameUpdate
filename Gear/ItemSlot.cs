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
    public void OnDrop(PointerEventData eventData) {
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
                Transform prevParent = drag.parent;
                this.transform.GetChild(0).position = prevParent.position;
                this.transform.GetChild(0).SetParent(prevParent);
                drag.SetParent(this.transform);
                drag.position = this.transform.position;
            }
        }
    }
}
