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
        //Random rand = new Random();
        for(int i = 0; i < playerList.Count; i++){
            
            int x = Random.Range(0,5);
            int y = Random.Range(0,5);
            
            Instantiate(playerPrefab, new Vector3(x, y, 0), Quaternion.identity);
            Debug.Log("Here");
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
