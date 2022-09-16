using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutHolder : MonoBehaviour
{
    public Loadout ldt;


    public bool isPlayer;
    public void Start()
    {
        if (CompareTag("Player")) // if player
        {
            ActivateLoadout();
        }
        else // if loadout displayer
        {
            LoadoutManager();
        }
    }
    public void ActivateLoadout()       // activate if player
    {
        // instantiate class icon and put into hierarchy
        // instantiate gears and put them into hierarchy
    }

    public void LoadoutManager()        // activate if loadout
    {

    }
    

}
