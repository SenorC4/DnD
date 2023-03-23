using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Firebolt : Spell
    {

        public Firebolt()
        {
            cost = 0;
            range = 120;
            sides = new int[] { 10 };
            modifier = 0;
            damage = 1;
            name = "Firebolt";

        }


    }

}
