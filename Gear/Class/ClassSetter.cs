using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClassSetter : MonoBehaviour, IPointerDownHandler
{
    public GameObject ldtClass;
    public string SettedClass; // every setter will have its own class to set
    public void OnPointerDown(PointerEventData eventData) // set new class for the loadout.
    {
        Debug.Log(SettedClass);
        ldtClass.GetComponent<ClassChooser>().changeClass(this.GetComponent<ClassHolder>().getClass());
    }
    public void Start()
    {
        // load data of the class that will be set.
        // get the class specification from SettedClass var.
    }
}
