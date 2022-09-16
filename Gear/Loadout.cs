using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout
{
    public string name;             // to specify builds
    public Gear Gear1;              // First Slot
    public Gear Gear2;              // Second Slot
    public Gear Gear3;              // Third Slot
    public Class cls;               // Class Slot

    public void instClass()
    {
        // instantiate class icon as head under the player object
    }
    public void instg1()
    {
        // instantiate first gear in its right place.
        // instantiate buttons for attacking
    }
    public void instg2()
    {
        // instantiate second gear in its right place.
        // instantiate buttons for attacking
    }
    public void instg3()
    {
        // instantiate third gear in its right place.
        // instantiate buttons for attacking
    }
}
