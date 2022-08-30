using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchantment
{
    new string name;
    string ExplanationText;
    int level;
    string type; // should become its own class to hold information of scaling and value types. // not sure about it
    // Icon for the Enchantment
    public Enchantment() // randomised Gen
    {
        name = "Testing Name";
        ExplanationText = "Testing.";
        level = 5; // will get this as a parameter from gear later on. !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        type = "Tester";
    }
    public Enchantment(string text, int lvl, string typeinfo)// type will change. 
    {
        ExplanationText = text;
        level = lvl;
        type = typeinfo;
    }
}
