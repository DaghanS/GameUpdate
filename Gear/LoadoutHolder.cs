using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutHolder : MonoBehaviour
{
    public Loadout ldt;
    public void Start()
    {
        if (CompareTag("Player")) // if player
        {
            UseLoadout();
        }
        else // if loadout displayer
        {
            LoadoutLoader();
        }
    }
    public void UseLoadout()       // using loadout in-game
    {
        // instantiate class icon and put into hierarchy
        // instantiate gears and put them into hierarchy
    }
    public void ActivateLoadout()
    {
        // run on click
        // set the loadout being held by this object 'Active Loadout'
    }

    public void LoadoutLoader()        // activate if loadout
    {
        ldt = new Loadout();
    }
    public void classEditor(Class newitem)
    {
        ldt.cls = newitem;
    }


    // Instantation
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
