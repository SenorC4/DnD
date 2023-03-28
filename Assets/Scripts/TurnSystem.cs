using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    [SerializeField] private List<GameObject> units;
    private List<GameObject> characters;
    private List<GameObject> enemies;
    private List<Spell> spells;
    private GameObject tempCharacter;
    //private GameObject temp = null;
    public bool middleOfTurn = false;
    private int index;
    public int move;
    public int attack;
    private bool created;
    private int damageDone = 0;
    public TMPro.TMP_Text stats;
    public TMPro.TMP_Text availableAttacks;
    public TMPro.TMP_Text damageRoll;

    private string attackString;
    private string statString;
    [SerializeField] public Pathfinder path = new Pathfinder();

    public GameObject characterCanvas;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void Update()
    {
       
        if (middleOfTurn)
        {
            damageRoll.text = "Damage Done: " + damageDone;
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].GetComponent<CharacterScript>().getHP() <= 0)
                {
                    GameObject tempCharacter = units[i];
                    //units.RemoveAt(i);
                    //Destroy(tempCharacter);
                }
                //Debug.Log("Size: " + units.Count);
            }
        }
    }

    void startPlaying()
    {
        middleOfTurn = true;
            if (units[index].GetComponent<CharacterScript>().getType() == "Skeleton" || units[index].GetComponent<CharacterScript>().getType() == "Warhorse Skeleton")
            {
                Debug.Log("Enemy");
                stats.text = "Unit: " + units[index].GetComponent<CharacterScript>().getType();
                makingMove();
                //endTurn();         
            }
            else
            {
                makingMove();
                Debug.Log(units[index].GetComponent<CharacterScript>().GetType());
                stats.text = "Unit: " + units[index].GetComponent<CharacterScript>().getType() + ", HP: " + units[index].GetComponent<CharacterScript>().getHP() + ", AC: " + units[index].GetComponent<CharacterScript>().getAC();
                spells = units[index].GetComponent<CharacterScript>().getSpells();
                Debug.Log(spells.Count);
                attackString = "Melee";
                for (int i = 0; i < spells.Count; i++)
                {
                    attackString += ", ";
                    attackString += spells[i].getName();
                }   
                //availableAttacks.text = attackString;
            }
        



    }

    void makingMove()
    {
        Debug.Log("Choose a move");
        //middleOfTurn = true;
    }

    public void endTurn()
    {
        
        stats.text = "";
        move = 0;
        attack = 0;
        index++;
        if (index == units.Count)
        {
            index = 0;
        }
        middleOfTurn = false;
        MouseController mc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseController>();
        mc.setPlayer(units[index].GetComponent<PlayerBehavior>());
        Debug.Log("Turn Ended");
        startPlaying();
    }


    public void moveSpace()
    {
        Debug.Log(move);
        if (!(move == 2 || attack == 1))
        {
            move++;
        }

    }

    public void makeAttack()
    {
        Debug.Log(attack);
        
        if (attack == 0 && move < 2)
        {
            attack++;
            units[index].GetComponent<CharacterScript>().meleeAttack(path);
            
        }
        
    }

    public void Played()
    {
        
        characters = characterCanvas.GetComponent<CharacterCreate>().getUnitList();
        //enemies = characterCanvas.GetComponent<CharacterCreate>().getEnemyList();
        Debug.Log("Turn Started");
        //.GameObject[] tempUnits = GameObject.FindGameObjectsWithTag("Player");
        /*for (int i = 0; i < tempUnits.Length; i++)
        {
            units.Add(tempUnits[i]);
            Debug.Log("added");
        }*/
        for (int i = 0; i < characters.Count; i++)
        {
            units.Add(characters[i]);
            Debug.Log("added");
        }
        //for (int i = 0; i < enemies.Count; i++)
        //{
        //    units.Add(enemies[i]);
        //    Debug.Log("added");
        //}


        //damageRoll.text = "Damage Done: " + damageDone;
        /*for (int i = 0; i < units.Count; i++)
        {

            //temp = Instantiate(units[i]);
            characters.Add(units[i].GetComponent<ClericScript>());
            Debug.Log(characters.Count);
        }*/
        endTurn();
        startPlaying();
    }

    public void setDamageDone(int damage)
    {
        damageDone = damage;
    }

}
