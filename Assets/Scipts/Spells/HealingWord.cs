using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class HealingWord : Spell
    {
        public HealingWord()
        {
            cost = 1;
            range = 60;
            sides = new int[] { 4 };
            modifier = 0;
            damage = -1;
            name = "Healing Word";

        }


    }

}
