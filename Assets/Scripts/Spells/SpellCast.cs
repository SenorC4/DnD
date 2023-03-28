using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCast : MonoBehaviour
{

    [SerializeField] public TMPro.TMP_Text spell1;
    [SerializeField] public TMPro.TMP_Text spell2;
    [SerializeField] public TMPro.TMP_Text spell3;

    private MouseController mc;

    // Start is called before the first frame update
    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Cursor").GetComponent<MouseController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSpells()
    {
        var player = mc.getPlayer();

        List<Spell> spells = player.GetComponent<CharacterScript>().getSpells();



        spell1.text = spells[0].getName();
        spell2.text = spells[1].getName();
        spell3.text = spells[2].getName();

    }
}
