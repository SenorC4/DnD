using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : CharacterScript
{

    // Start is called before the first frame update
    void Start()
    {
        setHP(75);
        setAC(14);//Scale mail
        //meleeDamage[0] = 1;//using a handaxe
        //meleeDamage[1] = 6;
        setMovement(30);
        setType("Wizard");
        spellList = new List<Spell>();    

    }

    void Update()
    {
        for(int i = 0; i < spellList.Count; i++)
        {
            Debug.Log(spellList[i]);
        }
    }

    public override int rollForMeleeDamage()
    {
        int totalDamage = 0;
        int ran;
        for (int i = 0; i < 1; i++)
        {
            ran = Random.Range(0, 6);
            totalDamage += ran;
        }
        return totalDamage;
    }

}
