using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class nameEntryBehavior : MonoBehaviour
{
    public globalScorekeep gl_scorekeep;
    public GameObject transitionToBonusGameObject;
    private debugMasterMenuBehavior debugMasterMenuBehavior;
    [SerializeField] private List<AudioSource> jingles;

    // Start is called before the first frame update
    void Start()
    {
        gl_scorekeep = globalScorekeep.Instance.GetComponent<globalScorekeep>();
        debugMasterMenuBehavior = GetComponent<debugMasterMenuBehavior>();
    }

    public void registerName(TMP_InputField inputtedText)
    {
        //gl_scorekeep.names[gl_scorekeep.placeBeaten] = inputtedText.text;
        gl_scorekeep.names.Insert(gl_scorekeep.placeBeaten, inputtedText.text);
        checkBonusEligible(inputtedText);
        gl_scorekeep.placeBeaten = 0;
        gl_scorekeep.hasReachedHighScore = false;
    }

    public void checkBonusEligible(TMP_InputField inputtedText)
    {
        if (inputtedText.text.Equals("AKB"))
        {
            transitionToBonusGameObject.SetActive(true);
        }
        else
        {
            if (inputtedText.text.Equals("BIL"))
            {
                jingles[0].Play();
            }
            if (inputtedText.text.Equals("CHU"))
            {
                jingles[1].Play();
            }
            if (inputtedText.text.Equals("CRZ"))
            {
                jingles[2].Play();
            }
            if (inputtedText.text.Equals("MKB"))
            {
                jingles[3].Play();
            }
            if (inputtedText.text.Equals("NGT"))
            {
                jingles[4].Play();
            }
            if (inputtedText.text.Equals("SC5"))
            {
                jingles[5].Play();
            }
            if (inputtedText.text.Equals("SMB"))
            {
                jingles[6].Play();
            }
            if (inputtedText.text.Equals("HO"))
            {
                jingles[7].Play();
            }
            if (inputtedText.text.Equals("SHO"))
            {
                jingles[8].Play();
            }
            if (inputtedText.text.Equals("SA2"))
            {
                jingles[9].Play();
            }
            if (inputtedText.text.Equals("SA3"))
            {
                jingles[10].Play();
            }
            if (inputtedText.text.Equals("RR4"))
            {
                jingles[11].Play();
            }
            StartCoroutine(transitionToRankings());
        }
    }

    IEnumerator transitionToRankings()
    {
        yield return new WaitForSeconds(5);
        debugMasterMenuBehavior.goToPresetSceneForRelease("ap_newtitle");
    }
}
