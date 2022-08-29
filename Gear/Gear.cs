using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear
{
    protected enum rarity{ 
        Common,
        Rare,
        Epic,
        Antique, // I plan Antique, Masterpiece and Accursed to be same level, different usages.
        Masterpiece,
        Accursed
    }
    rarity Rarity;
    protected int level;
    protected string reputation; // this is so awkward...
    // 3 enchantment class objects
    protected Enchantment ench1;
    protected Enchantment ench2;
    protected Enchantment ench3;
    protected string ExplanationText;
    // IconVar ??
    public Gear()
    {
    }
    public Gear(int rarinfo, int lvlinfo,
        string repinfo,
        Enchantment enchinfo1, Enchantment enchinfo2, Enchantment enchinfo3,
        string textinfo)
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
        reputation = repinfo;
        // enchantments are created here. We will need a lot of randomisers.
    }
}
