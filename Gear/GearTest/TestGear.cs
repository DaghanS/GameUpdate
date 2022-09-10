using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum rarity
{
    Common,
    Rare,
    Epic,
    Antique, // I plan Antique, Masterpiece and Accursed to be same level, different usages.
    Masterpiece,
    Accursed
}

public class TestGear
{
    int lvl;
    public string name;
    public TestIcon icon; // Icon // is public only to display, could change some systems 
    public rarity Rarity;

    public string description; // no constructor for nwo
    public TestGear()
    {
        // need a big function here to decide what type of item is going to be created.
        name = nameR();
        Rarity = rarityR();
        lvl = levelR();
        icon = new TestIcon(name, Rarity, lvl, description); // rn parameters dont do anything.
    }


    public string nameR()
    {
        // get class of player.
        // access list of gears that this class could receive
        // choose one type and get its name
        // set that name to "namer"
        string namer = "randomiser Testing.";
        return namer;
    }
    public rarity rarityR()  // working and enough for now.
    {
        rarity ran = rarity.Common;
        int chance = Random.Range(1, 101); // dont like this system.
        if (chance < 40)
        {
            ran = rarity.Common;
        }
        else if (chance < 70)
        {
            ran = rarity.Rare;
        }
        else if (chance < 95)
        {
            ran = rarity.Epic;
        }
        else
        {
            int roll = Random.Range(1, 4);
            switch (roll)
            {
                case 1:
                    ran = rarity.Antique;
                    break;
                case 2:
                    ran = rarity.Masterpiece;
                    break;
                case 3:
                    ran = rarity.Accursed;
                    break;
            }

        }
        return ran;
    }
    public int levelR()
    {
        // get current player class level
        // need an algorithm here: from the level of player, create a range of lvl, create a random lvl >> need to add endgame lvl grind >> but a reasonable system is needed
        int range; // should get character (class) level and get a range of +5 / -5 for that level (does not stop at level cap!(late game grind))


        // this is placeholder
        int chance = Random.Range(1, 41); // dont like this system.
        int lvl = chance;
        return lvl;
    }
}
