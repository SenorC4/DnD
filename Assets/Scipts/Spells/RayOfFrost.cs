using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class RayOfFrost : Spell
    {

        public RayOfFrost()
        {
            cost = 0;
            range = 60;
            sides = new int[] { 10 };
            modifier = 0;
            damage = 1;
            name = "Ray of Frost";

        }


    }

}
