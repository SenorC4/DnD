using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RayOfFrost : Spell
{

    public RayOfFrost()
    {
        cantrip = true;
        cost = 0;
        range = 60;
        sides = new int[] { 10 };
        modifier = 0;
        damage = 1;
        name = "Ray of Frost";

    }


}


