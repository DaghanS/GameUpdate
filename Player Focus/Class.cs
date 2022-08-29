using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class : MonoBehaviour
{

    // This script is supposed to hold player class data.
    new string name;
    // Every class has its own level - exp data
    int level;
    float exp;

    // Their own stats:
    float hp;
    float mana;
    // increasable stats: biraz komplikeleştiresim var?
    // for now I want levels to give enough stats that will enable you to max 2 of these only
    // but hp and mana are NOT taken into account
    float str;
    float intl;
    float agility;

}
