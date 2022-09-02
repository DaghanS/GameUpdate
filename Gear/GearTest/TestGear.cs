using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGear
{
    int lvl;
    string name;
    public TestIcon icon; // Icon // is public only to display, could change some systems 
    public enum rarity
    {
        Common,
        Rare,
        Epic,
        Antique, // I plan Antique, Masterpiece and Accursed to be same level, different usages.
        Masterpiece,
        Accursed
    }
    public rarity Rarity;

    //public TestGear(int level, string ItemName)
    //{
    //    lvl = level;
    //    name = ItemName; 
    //    icon = Resources.Load("Prefab/Gear/IconObject");
    //}
    public TestGear()
    {
        // need a big function here to decide what type of item is going to be created.
        name = nameR();
        Rarity = rarityR();
        lvl = levelR();
        icon = new TestIcon(); // later on will have name, rarity as parameters to find right sprites.
    }


    public string nameR()
    {
        string namer = "randomiser Testing.";
        return namer;
    }
    public rarity rarityR()
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
        int range; // should get character (class) level and get a range of +5 / -5 for that level (does not stop at level cap!(late game grind))
        int chance = Random.Range(1, 41); // dont like this system.
        int lvl = chance;
        return lvl;
    }
}
