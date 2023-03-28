using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCreate : MonoBehaviour
{
    public TMPro.TMP_Dropdown wSS1;
    public TMPro.TMP_Dropdown wSS2;
    public TMPro.TMP_Dropdown wSS3;
    public TMPro.TMP_Dropdown cSS1;
    public TMPro.TMP_Dropdown cSS2;
    public TMPro.TMP_Dropdown cSS3;

    public TMPro.TMP_Dropdown SkeletonDrop;
    public TMPro.TMP_Dropdown SkeletonHorseDrop;

    public TMPro.TMP_Text textOut;

    public GameObject wizardPre;
    public GameObject clericPre;
    public GameObject skelePre;
    public GameObject horseSkelePre;

    [SerializeField] public List<GameObject> playerList = new List<GameObject>();
    [SerializeField] public List<GameObject> enemyList = new List<GameObject>();
    
    


    public void addWizard(){
        string wizardText = "Wizard " + wSS1.options[wSS1.value].text + " " + wSS2.options[wSS2.value].text + " " + wSS3.options[wSS3.value].text;
        Debug.Log(wizardText);

        List<Spell> wizardSpells = new List<Spell>();

        if(wizardText.Contains("Slot")){
            textOut.text = "Please choose your spells";
        }else if(playerList.Count > 9){
            textOut.text = "Max number of players reached";
        }else{
            //parse spells from text and add them to the list
            if(wizardText.Contains("fire")){
                wizardSpells.Add(new Firebolt());
            }
            if(wizardText.Contains("Frost")){
                wizardSpells.Add(new RayOfFrost());
            }
            if(wizardText.Contains("Magic")){
                wizardSpells.Add(new MagicMissile());
            }
            if(wizardText.Contains("Scorching")){
                wizardSpells.Add(new ScorchingRay());
            }

            //Need random tile here
            ///
            ///
            GameObject wizard = Instantiate(wizardPre);
            wizard.AddComponent<WizardScript>();
            wizard.GetComponent<WizardScript>().setSpells(wizardSpells);

            textOut.text = "Added: " + wizardText;
            playerList.Add(wizard);
            wizardSpells.Clear();
        }
        Debug.Log(playerList.Count);
    }

    public void addCleric(){
        string clericText = "Cleric " + cSS1.options[cSS1.value].text + " " + cSS2.options[cSS2.value].text + " " + cSS3.options[cSS3.value].text;
        Debug.Log(clericText);

        List<Spell> clericSpells = new List<Spell>();

        if(clericText.Contains("Slot")){
            textOut.text = "Please choose your spells";
        }else if(playerList.Count > 9){
            textOut.text = "Max number of players reached";
        }else{
            if(clericText.Contains("1-Healing")){
                clericSpells.Add(new HealingWord());
            }
            if(clericText.Contains("2-Aid")){
                clericSpells.Add(new Aid());
            }
            if(clericText.Contains("2-Mass")){
                clericSpells.Add(new MassHealingWord());
            }

            //Need random tile here
            ///
            ///
            GameObject cleric = Instantiate(clericPre);
            cleric.AddComponent<ClericScript>();
            cleric.GetComponent<ClericScript>().setSpells(clericSpells);

            textOut.text = "Added: " + clericText;

            playerList.Add(cleric);
            clericSpells.Clear();
            
        }
        Debug.Log(playerList.Count);
    }

    public void addEnemies(){
        if((SkeletonDrop.value + SkeletonHorseDrop.value) <= 10){

            for(int i = 0; i < SkeletonDrop.value; i++){
                //enemyList.Add(new SkeletonScript());

                GameObject skeleton = Instantiate(skelePre);
                skeleton.AddComponent<SkeletonScript>();

                playerList.Add(skeleton);
            }
            
            for(int i = 0; i < SkeletonHorseDrop.value; i++){
                //enemyList.Add(new WarHorseSkeletonScript());
                GameObject skeletonHorse = Instantiate(horseSkelePre);
                skeletonHorse.AddComponent<WarHorseSkeletonScript>();

                playerList.Add(skeletonHorse);
            }



            textOut.text = "Added: " + SkeletonDrop.value + " Skeletons and " + SkeletonHorseDrop.value + " Warhorse Skeletons.";
        
        }else{
            textOut.text = "Max number of Enemies is 10";
        }

    }

    public List<GameObject> getPlayerList(){
        return playerList;
    }

    public List<GameObject> getEnemyList(){
        return enemyList;
    }
}
