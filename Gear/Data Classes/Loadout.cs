using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Loadout
{
    public string name;             // to specify builds
    public Gear Gear1;              // First Slot
    public Gear Gear2;              // Second Slot
    public Gear Gear3;              // Third Slot
    public Class cls;               // Class Slot

    // need a constructor.
    // need to construct loadouts as empty, and then load their information
    // or just construct with loaded information if I can 

    public Loadout()
    {
        name = "test";
        Gear1 = null;
        Gear2 = null;
        Gear3 = null;
        cls = null;
    }

    public void Editor(System.Object input) // this isn't really necessary right now?
    {
        Type iType = input.GetType();

        if (iType == typeof(Class))
        {
            cls = input as Class;
        }
        if (iType == typeof(Gear)) // need information of which gear
        {

        }
        if (iType == typeof(string))
        {
            name = input as string;
        }
    }
}
