using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    public class Driver : MonoBehaviour
    {
    
            /* This is just a demo of the iniative stuff working
             * 
             */
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");

                DiceRoller d = new DiceRoller();

                //fills and array of characters
                CharacterPlaceholder[] cp = new CharacterPlaceholder[10];

                for (int i = 0; i < 10; i++)
                {
                    cp[i] = new CharacterPlaceholder();
                    cp[i].name = "Person Number: " + i;
                }

                //sets the initiatve of them all, and sorts them
                d.initiativeSet(ref cp);
                d.initiativeSort(ref cp);

                //prints out the initiatives in order
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(cp[i].initiative + "  " + cp[i].name);
                }

                Console.WriteLine("This is an example of using spells");

                Firebolt fb = new Firebolt();
                MagicMissile mm = new MagicMissile();
                RayOfFrost rf = new RayOfFrost();
                ScorchingRay sr = new ScorchingRay();
                HealingWord hw = new HealingWord();
                MassHealingWord mhw = new MassHealingWord();
                Aid a = new Aid();

                Console.WriteLine("Firebolt's damage is: " + fb.getDamage());
                Console.WriteLine("MagicMissile's damage is: " + mm.getDamage());
                Console.WriteLine("Ray Of Frost's damage is: " + rf.getDamage());
                Console.WriteLine("Scorching Ray's damage is: " + sr.getDamage());
                Console.WriteLine("Healing Word's damage is: " + hw.getDamage());
                Console.WriteLine("Mass Healing Word's damage is: " + mhw.getDamage());
                Console.WriteLine("Aid's damage is: " + a.getDamage());



            }
        

    }
