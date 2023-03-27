using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public List<GameObject> units;
    private List<CharacterScript> characters;
    private CharacterScript tempCharacter;
    //private GameObject temp = null;
    public bool middleOfTurn = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Turn Started");
        for (int i = 0; i < units.Count-1; i++)
        {
            //temp = Instantiate(units[i]);
            characters.Add(units[i].GetComponent<CharacterScript>());
        }
        startPlaying();
        Debug.Log("Turn Started");
    }


    void startPlaying()
    {
        while (characters.Count > 0)
        {
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].getType() == "skeleton" || characters[i].getType() == "horse")
                {
                    Debug.Log("Enemy");
                    while (middleOfTurn == true)
                    {
                        endTurn();
                    }
                }
                else
                {
                    Debug.Log("Player");
                    makingMove();
                    while (middleOfTurn == true)
                    {

                    }
                }
            }
        }

    }


    void makingMove()
    {
        Debug.Log("Choose a move");
        middleOfTurn = true;
    }

    public void endTurn()
    {
        middleOfTurn = false;
        Debug.Log("Turn Ended");
    }



}
