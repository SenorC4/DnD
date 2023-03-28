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
    [SerializeField] public List<GameObject> units = new List<GameObject>();

    private OverlayTile tile;
    private MouseController mc;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseController>();
    }

    public void addWizard(){
        string wizardText = "Wizard " + wSS1.options[wSS1.value].text + " " + wSS2.options[wSS2.value].text + " " + wSS3.options[wSS3.value].text;
        Debug.Log(wizardText);

        List<Spell> wizardSpells = new List<Spell>();

        if (wizardText.Contains("Slot")){
            textOut.text = "Please choose your spells";
        }else if(playerList.Count > 4){
            textOut.text = "Max number of players reached";
        }else{
            //parse spells from text and add them to the list
            if(wizardText.Contains("fire")){
                //Spell fire = new Firebolt();
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
            //wizard.AddComponent<WizardScript>();
            

            PlayerBehavior player = wizard.GetComponent<PlayerBehavior>();
            player.transform.position = new Vector3(MapManager.instance.current.transform.position.x, MapManager.instance.current.transform.position.y, MapManager.instance.current.transform.position.z);
            player.GetComponent<SpriteRenderer>().sortingOrder = MapManager.instance.current.GetComponent<SpriteRenderer>().sortingOrder;
            player.activeTile = MapManager.instance.current;
            MapManager.instance.setCurrentNewRand();
            mc.setPlayer(player);

            wizard.GetComponent<WizardScript>().setSpells(wizardSpells);

            textOut.text = "Added: " + wizardText;
            playerList.Add(wizard);
            units.Add(wizard);
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
        }else if(playerList.Count > 4){
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
                Debug.Log("Made it Here -----------------------------------------------------------------");
                Debug.Log(clericSpells[0]);
            }

            //Need random tile here
            ///
            ///
            GameObject cleric = Instantiate(clericPre);
            //cleric.AddComponent<ClericScript>();
            cleric.GetComponent<ClericScript>().setSpells(clericSpells);

            PlayerBehavior player = cleric.GetComponent<PlayerBehavior>();
            player.transform.position = new Vector3(MapManager.instance.current.transform.position.x, MapManager.instance.current.transform.position.y, MapManager.instance.current.transform.position.z);
            player.GetComponent<SpriteRenderer>().sortingOrder = MapManager.instance.current.GetComponent<SpriteRenderer>().sortingOrder;
            player.activeTile = MapManager.instance.current;
            MapManager.instance.setCurrentNewRand();
            mc.setPlayer(player);

            textOut.text = "Added: " + clericText;

            playerList.Add(cleric);
            units.Add(cleric);
            clericSpells.Clear();
            
        }
        Debug.Log(playerList.Count);
    }

    public void addEnemies(){
        if((SkeletonDrop.value + SkeletonHorseDrop.value + enemyList.Count) <= 5){
            Debug.Log(SkeletonDrop.value + " " + SkeletonHorseDrop.value);
            for(int i = 0; i < SkeletonDrop.value; i++){
                

                GameObject skeleton = Instantiate(skelePre);
                //skeleton.AddComponent<SkeletonScript>();

                PlayerBehavior player = skeleton.GetComponent<PlayerBehavior>();
                player.transform.position = new Vector3(MapManager.instance.current.transform.position.x, MapManager.instance.current.transform.position.y, MapManager.instance.current.transform.position.z);
                player.GetComponent<SpriteRenderer>().sortingOrder = MapManager.instance.current.GetComponent<SpriteRenderer>().sortingOrder;
                player.activeTile = MapManager.instance.current;
                MapManager.instance.setCurrentNewRand();
                mc.setPlayer(player);

                enemyList.Add(skeleton);
                units.Add(skeleton);
            }
            
            for(int i = 0; i < SkeletonHorseDrop.value; i++){
                
                GameObject skeletonHorse = Instantiate(horseSkelePre);
               // skeletonHorse.AddComponent<WarHorseSkeletonScript>();

                PlayerBehavior player = skeletonHorse.GetComponent<PlayerBehavior>();
                player.transform.position = new Vector3(MapManager.instance.current.transform.position.x, MapManager.instance.current.transform.position.y, MapManager.instance.current.transform.position.z);
                player.GetComponent<SpriteRenderer>().sortingOrder = MapManager.instance.current.GetComponent<SpriteRenderer>().sortingOrder;
                player.activeTile = MapManager.instance.current;
                MapManager.instance.setCurrentNewRand();
                mc.setPlayer(player);

                enemyList.Add(skeletonHorse);
                units.Add(skeletonHorse);
            }



            textOut.text = "Added: " + SkeletonDrop.value + " Skeletons and " + SkeletonHorseDrop.value + " Warhorse Skeletons.";
        
        }else{
            textOut.text = "Max number of Enemies is 5";
        }

    }

    public List<GameObject> getPlayerList(){
        return playerList;
    }

    public List<GameObject> getEnemyList(){
        return enemyList;
    }

    public List<GameObject> getUnitList()
    {
        return units;
    }
}
