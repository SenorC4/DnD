﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Spell
{
    DiceRoller d = new DiceRoller();
    public string name;
    public int[] sides;
    public int range;
    public int modifier;
    public int damage; //1 is damaging, -1 is healing
    public int cost;
    public bool cantrip = false;


    public int getRange()
    {
        return range;
    }

    public int getDamage()
    {
        return d.CastingRoll(sides, modifier) * damage;
    }

    public string getName()
    {
        return name;
    }

    public bool isCantrp()
    {
        return cantrip;
    }

}
