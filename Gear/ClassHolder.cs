using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassHolder : MonoBehaviour
{
    public Class clsinfo;

    public Class getClass()
    {
        return clsinfo;
    }
    public void setClass(Class input)
    {
        clsinfo = input;
    }

    public void Start()
    {
        // on start load the information of spesific class for this object.
        GameObject definedClass = transform.Find();
    }
}
