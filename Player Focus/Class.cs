using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class
{
    // Just like inventory data, needs to be saved and loaded at the start of the game and reachable anytime.
    // there are different scenes that needs to get player level data
    // could add a class unlocking system so propably need to add more variables to this class.

    // This script is supposed to hold player class data.
    string name;
    // Every class has its own level - exp data
    int level;
    float exp;

    // Their own stats:
    float str; // strength: damage, HP
    float agi; // agility: damage, speed / attack speed
    float vig; // vigor: energy , HP
    float unique; // 1 or 2 unique categories for every class.

    public Class()
    {
        name = "testclass";
        level = 10;
        exp = 30;
        str = 0;
        agi = 0;
        vig = 0;
        unique = 0;
    }

}
