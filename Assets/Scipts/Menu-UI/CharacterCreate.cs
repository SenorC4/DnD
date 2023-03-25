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

    public TMPro.TMP_Text textOut;

    
    


    public void addWizard(){
        string wizardText = "Wizard " + wSS1.options[wSS1.value].text + " " + wSS2.options[wSS2.value].text + " " + wSS3.options[wSS3.value].text;
        Debug.Log(wizardText);

        List<Spell> wizardSpells = new List<Spell>();

        if(wizardText.Contains("Slot")){
            textOut.text = "Please choose your spells";
        }else{
            //parse spells from text and add them to the list

            textOut.text = "Added: " + wizardText;
            WizardScript wizard = new WizardScript(wizardSpells);
            //find a way to move the characters to the game scene
        }
    }

    public void addCleric(){
        string clericText = "Cleric " + cSS1.options[cSS1.value].text + " " + cSS2.options[cSS2.value].text + " " + cSS3.options[cSS3.value].text;
        Debug.Log(clericText);

        List<Spell> clericSpells = new List<Spell>();

        if(clericText.Contains("Slot")){
            textOut.text = "Please choose your spells";
        }else{
            //parse spells from text and add them to the list



            textOut.text = "Added: " + clericText;

            ClericScript cleric = new ClericScript(clericSpells);
            //find a way to move the characters to the game scene
        }
    }

}
