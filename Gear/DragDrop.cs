﻿/* 
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


    private Transform tf;  // if recttransform fails, we'll have to do conversions from vector 2 to vector3 which is easy but hopefully unnecessary
    private CanvasGroup canvasGroup;
    public GameObject menu;
    public int counter;


    private void Awake() {
        counter = 0;
        menu = transform.Find("HoverMenu(Clone)").gameObject;
        tf = GetComponent<Transform>();
        GameObject canvasobj = GameObject.Find("BG_Canvas");
    }
    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        // save current location (may not be needed)
        // save current slot, object will return to slots center if not inserted.
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        // if not inserted into another inv slot
        // return back to start location (pinned into slot location)
    }
    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        tf.position = eventData.pointerCurrentRaycast.worldPosition;
    }
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDownONGEAR");

        if (counter == 1)
        {
            if (menu.activeInHierarchy) menu.SetActive(false);
            else menu.SetActive(true);
            counter = 0;
        }
        else
        {
            counter++;
            menu.SetActive(false);
        }
    }

}