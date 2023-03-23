using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Aid : Spell
    {
        public Aid()
        {
            cost = 2;
            range = 30;
            sides = new int[] { };
            modifier = 5;
            damage = -1;
            name = "Aid";

        }


    }

}
