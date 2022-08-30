using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearInfo : MonoBehaviour
{
    public Gear Information;
    int checker;

    public void GearCreation()
    {
        Information = new Gear(); // randomised Gen
        checker = 1;
        checker += 1;
    }
    public void Start()
    {
        GearCreation();
    }
}
