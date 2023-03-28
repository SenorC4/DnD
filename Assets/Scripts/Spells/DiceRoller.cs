using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    class DiceRoller
    {
        /*this method gives you a random dice result
         * give it a number of sides, and it spits
         * out the result */

        public int DiceRoll(int sides)
        {
            var rand = new System.Random();

            int x = rand.Next(sides);
            x += 1;
            return x;
        }

        public int CastingRoll(int[] sides, int bonus)
        {
            int sum = 0;
            for (int i = 0; i < sides.Length; i++)
            {
                sum += DiceRoll(sides[i]);
            }
            sum += bonus;
            return sum;

        }

        /* This method is to get the initiative of each of the characters
         * For each it sets the initiative value to something random between 1 and 20
         * This can be implemented differently later, but just a method atm
         */
        public void initiativeSet(ref CharacterPlaceholder[] characters)
        {

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].initiative = DiceRoll(20);
            }

        }

        /* This method takes an array of characters and sorts
         * the array based on their initiative value
         */
        public void initiativeSort(ref CharacterPlaceholder[] characters)
        {

            for (int i = 0; i < characters.Length; i++)
            {
                for (int j = i + 1; j < characters.Length; j++)
                {
                    if (characters[i].initiative < characters[j].initiative)
                    {
                        CharacterPlaceholder temp = characters[i];
                        characters[i] = characters[j];
                        characters[j] = temp;

                    }


                }
            }


        }


    }


