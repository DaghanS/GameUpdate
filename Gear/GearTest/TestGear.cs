using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGear
{
    int lvl;
    string name;
    public Object icon; // Icon // is public only to display, could change some systems 

    public TestGear(int level, string ItemName)
    {
        lvl = level;
        name = ItemName; 
        icon = Resources.Load("Prefab/Gear/IconObject");
    }
}
