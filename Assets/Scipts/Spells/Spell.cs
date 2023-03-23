using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Spell : MonoBehaviour
    {
        DiceRoller d = new DiceRoller();

        public int[] sides;
        public int range;
        public int modifier;
        public int damage; //1 is damaging, -1 is healing
        public int cost;

        public Spell()
        {

        }

        public int getRange()
        {
            return range;
        }

        public int getDamage()
        {
            return d.CastingRoll(sides, modifier) * damage;
        }

    }

}
