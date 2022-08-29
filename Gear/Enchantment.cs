using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enchantment
{
    string ExplanationText;
    int level;
    string type; // should become its own class to hold information of scaling and value types.
    // Icon for the Enchantment

    public Enchantment(string text, int lvl, string typeinfo)// type will change. 
    {
        ExplanationText = text;
        level = lvl;
        type = typeinfo;
    }
}
