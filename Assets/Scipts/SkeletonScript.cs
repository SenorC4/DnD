using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : CharacterScript
{

    //private string enemyClass = "skeleton";
    //private int skeletonNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        setHP(13);
        setAC(13);
        //meleeDamage[0] = 1;//using a shortsword
        //meleeDamage[1] = 6;
        setMovement(30);
        setType("skeleton");
        setNum(1);
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

    // Update is called once per frame
    void Update()
    {
        
    }

}
