using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class MagicMissile : Spell
    {

        public MagicMissile()
        {
            cost = 1;
            range = 120;
            sides = new int[] { 4, 4, 4 };
            modifier = 3;
            damage = 1;
            name = "Magic Missile";

        }


    }

}
