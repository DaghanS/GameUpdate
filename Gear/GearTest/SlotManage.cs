using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManage : MonoBehaviour, IPointerDownHandler
{
    bool carrier;
    GameObject menu;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if (carrier)
        {
            if (menu.activeInHierarchy) menu.SetActive(false);
            else menu.SetActive(true);
        }
    }
    public void slotFilling(GameObject hvr)
    {
        carrier = true;
        menu = hvr;
    }
}
