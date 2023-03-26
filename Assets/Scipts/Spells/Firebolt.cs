using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Firebolt : Spell
{

    public Firebolt()
    {
        cantrip = true;
        cost = 0;
        range = 120;
        sides = new int[] { 10 };
        modifier = 0;
        damage = 1;
        name = "Firebolt";

    }


}


