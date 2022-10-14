using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearStatus : MonoBehaviour
{
    public TestGear gear;
    public bool ifEquipped;
    public GameObject equipped;
    public void Set(TestGear input)
    {
        gear = input;
        ifEquipped = false;
        equipped = null;
    }
}
