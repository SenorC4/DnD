
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class CharacterScript: MonoBehaviour
{
    private int HP;
    private int AC;
    //public int[] meleeDamage = new int[2];//the first element will be how many rolls and the second is the kind of die it is
    private int Movement;
    public List<GameObject> enemies;
    private string type;
    private int num;
    public Pathfinder p;
    public List<Spell> spellList = new List<Spell>();

    public int getNum()
    {
        return num;
    }

    public void setNum(int num)
    {
        this.num = num;    
    }
    public int getHP()
    {
        return HP;
    }

    public void setHP(int Health)
    {
        HP = Health;
    }
    public string getType()
    {
        return type;
    }

    public void setType(string characterType)
    {
        type = characterType;
    }

    public void setSpells(List<Spell> spellsIn)
    {
        for(int i = 0; i < spellsIn.Count; i++)
        {
            spellList.Add(spellsIn[i]);
            Debug.Log(spellList[i]);
        }
    }

    public List<Spell> getSpells()
    {
        for (int i = 0; i < spellList.Count; i++)
        {
            Debug.Log(spellList[i]);
        }
            
        return spellList;

    }

    public int getArmorClass()
    {
        return AC;
    }

    public void setAC(int Armor)
    {
        AC = Armor;
    }

    public int getAC()
    {
        return AC;
    }

    public int getMovement()
    {
        return Movement;
    }

    public void setMovement(int move)
    {
        Movement = move;
    }

    public void takeDamage(int damage)
    {
        HP -= damage;
    }

    public void meleeAttack(Pathfinder p)
    {
        //other.gameObject.GetComponent<CharacterScript>().takeDamage(rollForMeleeDamage());
        List<OverlayTile> tiles = p.getNeighborMouse(gameObject.GetComponent<PlayerBehavior>().activeTile);
        for (int i = 0;  i < tiles.Count; i++)
        {
            tiles[i].ShowTile();
            tiles[i].isAttackable = true;
        }
    }


    public abstract int rollForMeleeDamage();
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] temp;
        temp = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject temp[] = GameObject.tag("Enemy");
        for (int i = 0; i < temp.Length; i++) enemies.Add(temp[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
