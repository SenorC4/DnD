using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ScorchingRay : Spell
    {

        public ScorchingRay()
        {
            cost = 2;
            range = 120;
            sides = new int[] { 6, 6 };
            modifier = 0;
            damage = 1;
            name = "Scorching Ray";

        }


    }


