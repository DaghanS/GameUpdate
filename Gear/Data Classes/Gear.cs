using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear
{
    string name;
    public enum rarity{ 
        Common,
        Rare,
        Epic,
        Antique, // I plan Antique, Masterpiece and Accursed to be same level, different usages.
        Masterpiece,
        Accursed
    }
    public rarity Rarity;
    public int level;
    // 3 enchantment class objects
    // and their amounts
    int enchAmount; // I want this to unlock as Levels are improved?
    public Enchantment ench1;
    public Enchantment ench2;
    public Enchantment ench3;
    public string ExplanationText;
    Icon gearIcon;
    public Gear(int rarinfo, int lvlinfo, string textinfo)
    {
        switch (rarinfo)
        {
            case 1:
                Rarity = rarity.Common;
                break;
            case 2:
                Rarity = rarity.Rare;
                break;
            case 3:
                Rarity = rarity.Epic;
                break;
            case 4:
                Rarity = rarity.Antique;
                break;
            case 5:
                Rarity = rarity.Masterpiece;
                break;
            case 6:
                Rarity = rarity.Accursed;
                break;
        } //rarity setting.
        level = lvlinfo;
        // enchantments are created here. We will need a lot of randomisers.
        ench1 = new Enchantment();
        ench2 = new Enchantment();
        ench3 = new Enchantment();
        ExplanationText = textinfo; // explanations will be prepared early.
    }
    public Gear()  // NOT VERY COMPLEX RANDOMISED CONSTRUCTOR. 
    {
        Rarity = rarityR();
        level = levelR();
        ExplanationText = textLoader();
        enchAmount = EnchAmountR(level);
        // randomly create enchamount amount of enchantments
        // get text

        // get Icon:
        // need an algorithm that finds the right Images / Animations for the Icon.
        // with those variables we need to create an Icon Object.


    } // VERY COMPLEX RANDOMISED CONSTRUCTOR. 

    public string gearType(Class cls)
    {
        // choose a type of gear that is compatible with current class.
        // could be chosen elsewhere???
        string chosen = "test";
        return chosen;
    }
    public rarity rarityR()
    {
        rarity ran = rarity.Common;
        int chance = Random.Range(1, 101); // dont like this system.
        if(chance < 40)
        {
            ran = rarity.Common;
        }
        else if (chance < 70)
        {
            ran = rarity.Rare;
        }
        else if( chance < 95)
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
    public string textLoader() // could get name var as parameter to get right text later on.
    {
        // I need a database that I will get the descriptions from.
        // So I can load prepared text that will be displayed.
        // for now I will just display "testing".
        string expText = "testing.";
        return expText;
    }
    public int EnchAmountR(int level)
    {
        int amount = 0;
        if (level < 20 )
        {
            amount = 0;   
        }
        else if(level < 40)
        {
            amount = 1;
        }
        else if (level < 60)
        {
            amount = 2;
        }
        else
        {
            amount = 3;
        }
        return amount;
    }
}
