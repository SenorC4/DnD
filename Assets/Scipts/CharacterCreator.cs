using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public List<CharacterScript> playerList = CharacterCreate.getPlayerList();
    public List<CharacterScript> enemyList = CharacterCreate.getEnemyList();

    public List<GameObject> playerPrefabList = new List<GameObject>();

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < playerList.Count; i++){
            //playerPrefabList.Add(Instantiate(playerPrefab));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> getPlayerList(){

        return playerPrefabList;
    }


}
