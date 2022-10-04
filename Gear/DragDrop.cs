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

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {


    const float scale = 0.06107f; // is the scale of canvas. had problems with accessing canvas size because it is linked to camera


    public Transform tf;
    public CanvasGroup cg;
    public CircleCollider2D col;
    public GameObject menu;
    public void Awake()
    {
        tf = this.transform;
        cg = this.GetComponent<CanvasGroup>();
        col = this.GetComponent<CircleCollider2D>();
        //menu = transform.Find("HoverMenu(Clone)").gameObject;
    }
    
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        // transparency settings!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        cg.blocksRaycasts = false;
        col.enabled = false; // without this colider adjustment, onDrop does not trigger.
        menu.SetActive(false);  // menu should be deactivated while dragging, no conditions.
        // save current location (may not be needed)
        // save current slot, object will return to slots center if not inserted.
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        // use sprite renderer to affect transparency
        col.enabled = true; // without this colider adjustment, onDrop does not trigger.
        cg.alpha = 1f;
        cg.blocksRaycasts = true;
        // if not inserted into another inv slot
        // return back to start location (pinned into slot location)
    }
    public void OnDrag(PointerEventData eventData) {
        tf.position = eventData.pointerCurrentRaycast.worldPosition;
    }
    public void OnPointerDown(PointerEventData eventData) {  
        Debug.Log("OnPointerDownONGEAR");
        if (menu.activeInHierarchy) menu.SetActive(false);
        else menu.SetActive(true);
    }

}
