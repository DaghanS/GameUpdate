using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGear
{
    int lvl;
    string name;
    public Object ic; // Icon // is public only to display, could change some systems 

    public TestGear(int level, string ItemName)
    {
        lvl = level;
        name = ItemName; 
        ic = Resources.Load("Prefab/Gear/IconObject");
    }
}
