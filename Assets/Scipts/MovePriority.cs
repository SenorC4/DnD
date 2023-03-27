using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePriority : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    CharacterScript playerToAttack(List<CharacterScript> playerList, CharacterScript enemy)
    {
        List<double> priorities = new List<double>();
        List<int> movement = new List<int>();
        List<int> health = new List<int>();

        //gets the data and puts in into a list
        for (int i = 0; i < playerList.Count; i++)
        {
            priorities.Add(0);

            movement.Add(playerList[i].getMovement());
            health.Add(playerList[i].getHP());
        }

        //creates a priority ranking based on remaining HP and how far the character can move
        for(int i=0; i<playerList.Count; i++)
        {

            int denominator = 60;
            if (playerList[i].getType().Equals("wizard"))
            {
                denominator = 75;
            }

            //to shift priorities, change these two values
            double hpVal = playerList[i].getHP() / denominator; 
            double moveVal = playerList[i].getMovement() / 40;

            priorities[i] = hpVal + moveVal;

        }

        //this code gets the characterScript with the highest priority then returns it
        CharacterScript toAttack = null;
        int index = 0;
        if(playerList[0] != null)
        {
            toAttack = playerList[0];
        }

        for(int i=0; i<priorities.Count; i++)
        {
           if(priorities[i] > priorities[index])
            {
                index = i;
                toAttack = playerList[i];
            }
        }


        return toAttack;
    }

}
