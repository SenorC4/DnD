using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public List<GameObject> units;
    private List<CharacterScript> characters;
    private CharacterScript tempCharacter;
    private GameObject temp;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < units.Count; i++)
        {
            temp = Instantiate(units[i]);
            characters.Add(temp.GetComponent<CharacterScript>());
        }
        startPlaying();
    }


    void startPlaying()
    {
        Debug.Log("HI");
    }

}
