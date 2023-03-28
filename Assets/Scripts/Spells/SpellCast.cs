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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSpells()
    {
        spell1.text = "Firebolt";
        spell2.text = "Ray Of Scorching";
        spell3.text = "Aid";

    }
}
