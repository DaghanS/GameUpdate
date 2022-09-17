using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GearChooser : MonoBehaviour, IPointerDownHandler
// click on one gear icon to get gear recommendations
{
    GameObject menu;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDownGear");

        if (menu.activeInHierarchy) menu.SetActive(false);
        else menu.SetActive(true);
    }

    public void menuCreation()
    {

    }
    private void Start()
    {
        menuCreation();   
    }

}