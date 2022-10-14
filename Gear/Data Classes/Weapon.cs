using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Gear
{
    public string type;             // type and animator are linked, every type has their own animation.
    // also every type has its own scaling.
    // could become a separate class

    public float damage;            // attack damage.
    public float attackSpeed;       // changes animation speed.

    // will add three slots that can be filled with randomised effects = poison, bleeding, status effects, speed bonus, range bonus etc.
    public Weapon() : base()
    {
        type = null;
        damage = 40;
        attackSpeed = 1;
    }
    public Weapon(string typinfo, float dmginfo, float asinfo) : base()
    {
        type = typinfo;
        damage = dmginfo;
        attackSpeed = asinfo;
    }
}
