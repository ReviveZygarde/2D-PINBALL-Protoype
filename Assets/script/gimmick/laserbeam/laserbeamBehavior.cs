using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserbeamBehavior : MonoBehaviour
{
    public ModeBehavior modeBehavior;
    private SpriteRenderer sprr;
    private Collider2D col;
    private tableTally tallier;
    public GameObject alertEffect;

    // Start is called before the first frame update
    void Start()
    {
        modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        sprr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        tallier = GameObject.Find("common").GetComponent<tableTally>();
    }  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(alertEffect != null)
        {
            alertEffect.SetActive(false);
            alertEffect.SetActive(true);
        }
        tallier.criteria_hole3entry++;
        tallier.hole_2_3_rampCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if(modeBehavior.modeState != ModeBehavior.currentMode.NORMAL)
        {
            sprr.enabled = false;
            col.enabled = false;
        }
        else
        {
            sprr.enabled = true;
            col.enabled = true;
        }
    }
}
