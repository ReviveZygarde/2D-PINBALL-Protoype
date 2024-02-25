using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shakePrompter : MonoBehaviour
{
    private SpriteRenderer spr;
    private GameObject pinball;
    public SpriteRenderer sprr_ctrlAC;
    public SpriteRenderer sprr_ctrlB;
    public rouletteRimDashPanel markerDashPanel;
    [SerializeField] private GameObject ControlTypeAandCPrompt;
    [SerializeField] private GameObject ControlTypeBPrompt;
    //public GameObject objectToCopy_Y;
    public AudioSource jingle;

    // Start is called before the first frame update
    void Start()
    {
        sprr_ctrlAC.enabled = false;
        sprr_ctrlB.enabled = false;
        spr = GetComponent<SpriteRenderer>();
        spr.enabled = false;
        //objectToCopy_Y = GameObject.Find("Main Camera");
        pinball = GameObject.Find("Pinball");
        StartCoroutine(showPrompt());
    }

    private void OnEnable()
    {
        if (spr != null)
        {
            spr.enabled = false;
            sprr_ctrlAC.enabled = false;
            sprr_ctrlB.enabled = false;
            StartCoroutine(showPrompt());
        }
    }

    IEnumerator showPrompt()
    {
        yield return new WaitForSeconds(3);

        while(markerDashPanel.markerPassCount <= markerDashPanel.markerPassCountGoal)
        {
            if(pinball.layer == 9)
            {
                spr.enabled = true;
                switch (globalSetting.Instance.Control_Type)
                {
                    case globalSetting.controlType.A:
                        sprr_ctrlAC.enabled = true;
                        break;
                    case globalSetting.controlType.B:
                        sprr_ctrlB.enabled = true;
                        break;
                    case globalSetting.controlType.C:
                        sprr_ctrlAC.enabled = true;
                        break;
                }
                jingle.Play();
                yield return new WaitForSeconds(0.5f);
                spr.enabled = false;
                sprr_ctrlAC.enabled = false;
                sprr_ctrlB.enabled = false;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(1f);
        }
        if(markerDashPanel.markerPassCount >= markerDashPanel.markerPassCountGoal)
        {
            spr.enabled = false;
            sprr_ctrlAC.enabled = false;
            sprr_ctrlB.enabled = false;
        }
        yield return null;
    }
}
