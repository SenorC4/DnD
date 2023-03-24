using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClericScript : CharacterScript
{

    List<Spell> spellList;


    // Start is called before the first frame update
    void Start()
    {
        
        setHP(60);
        setAC(16);//chain mail
        //meleeDamage[0] = 2;//using a maul
        //meleeDamage[1] = 6;
        setMovement(25);
        setType("cleric");
        spellList = new List<Spell>();
    }

    public ClericScript(List<Spell> ingestSpells){
        spellList = ingestSpells;
    }

    public override int rollForMeleeDamage()
    {
        int totalDamage = 0;
        int ran;
        for (int i = 0; i < 2; i++)
        {
            ran = Random.Range(0, 6);
            totalDamage += ran;
        }
        return totalDamage;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
