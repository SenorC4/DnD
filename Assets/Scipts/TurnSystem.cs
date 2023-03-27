using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> units;
    private List<CharacterScript> characters;
    private CharacterScript tempCharacter;
    //private GameObject temp = null;
    public bool middleOfTurn = false;
    public int index;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Turn Started");
        GameObject[] tempUnits = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < tempUnits.Length; i++)
        {
            units.Add(tempUnits[i]);
            Debug.Log("added");
        }



        /*for (int i = 0; i < units.Count; i++)
        {
            
            //temp = Instantiate(units[i]);
            characters.Add(units[i].GetComponent<ClericScript>());
            Debug.Log(characters.Count);
        }*/
        startPlaying();
        Debug.Log("Turn Started");
    }

    private void Update()
    {
        if (middleOfTurn)
        {

        }
    }

    void startPlaying()
    {
        middleOfTurn = true;
                if (units[index].tag == "skeleton" || units[index].tag == "horse")
                {
                    Debug.Log("Enemy");
                        endTurn();
                    
                }
                else
                {
                    makingMove();
                    Debug.Log(units[index].GetComponent<CharacterScript>().GetType());
                }
            
        

    }

    void makingMove()
    {
        Debug.Log("Choose a move");
        //middleOfTurn = true;
    }

    public void endTurn()
    {
        index++;
        if (index == units.Count)
        {
            index = 0;
        }
        middleOfTurn = false;
        Debug.Log("Turn Ended");
        startPlaying();
    }



}
