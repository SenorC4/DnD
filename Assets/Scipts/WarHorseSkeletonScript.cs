using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHorseSkeletonScript : CharacterScript
{
    // Start is called before the first frame update
    void Start()
    {
        setHP(22);
        setAC(13);
        //meleeDamage[0] = 2;//using a shortsword
        //meleeDamage[1] = 6;
        setMovement(30);
        setType("Warhorse Skeleton");
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
        return totalDamage + 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
