using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ClassChooser : MonoBehaviour, IPointerDownHandler
// click on class icon to choose a class to play with 
{
    GameObject menu;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDownClass");

        if (menu.activeInHierarchy) menu.SetActive(false);
        else menu.SetActive(true);
    }
    public void Start()
    {
        menu = this.transform.Find("classmenu").gameObject;
    }

    public void changeClass(Class inputcls)
    {
        this.GetComponent<ClassHolder>().setClass(inputcls);
        gameObject.GetComponentInParent<LoadoutHolder>().classEditor(inputcls);
    }
}