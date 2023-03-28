using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MassHealingWord : Spell
{
    public MassHealingWord()
    {
        cost = 3;
        range = 60;
        sides = new int[] { 4 };
        modifier = 0;
        damage = -1;
        name = "Mass Healing Word";

    }


}


