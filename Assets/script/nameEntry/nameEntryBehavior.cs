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
    [SerializeField] private TMP_InputField textToCapitalize;
    private disableThenEnable characterFadeOutSequence;
    [SerializeField] private GameObject leaderboardParent;

    // Start is called before the first frame update
    void Start()
    {
        textToCapitalize = GameObject.Find("nameInputField").GetComponent<TMP_InputField>();
        gl_scorekeep = globalScorekeep.Instance.GetComponent<globalScorekeep>();
        debugMasterMenuBehavior = GetComponent<debugMasterMenuBehavior>();
        characterFadeOutSequence = GetComponent<disableThenEnable>();
    }

    public void registerName(TMP_InputField inputtedText)
    {
        //gl_scorekeep.names[gl_scorekeep.placeBeaten] = inputtedText.text;
        if(inputtedText.text.Equals("") || inputtedText.text.Equals(" ") || inputtedText.text.Equals("  ") || inputtedText.text.Equals("   "))
        {
            Debug.Log("Empty name or name only consists of spaces.");
            return;
        }
        GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
        gl_scorekeep.names.Insert(gl_scorekeep.placeBeaten, inputtedText.text);
        checkBonusEligible(inputtedText);
        GameObject.Find("EventSystem").SetActive(false); //Disable event system so the player doesn't spam the entry.
        characterFadeOutSequence.disableDesiredObject();
    }

    public void checkBonusEligible(TMP_InputField inputtedText)
    {
        if (inputtedText.text.Equals("AKB"))
        {
            transitionToBonusGameObject.SetActive(true); //Start the transition to the bonus game (Anklebreaker).
        }
        else
        {
            leaderboardParent.SetActive(true); //leaderboard rankings fly in
            foreach (AudioSource jingle in jingles)
            {
                if (inputtedText.text.Equals(jingle.name)) //if the inputted name matches the GameObject name of
                                                           //the AudioSource, play that AudioSource that has the matching name.
                {
                    jingle.Play();
                }
            }
            StartCoroutine(transitionToRankings());
        }
        //Reset the GL_scorekeeping values.
        gl_scorekeep.placeBeaten = 0;
        gl_scorekeep.hasReachedHighScore = false;
    }

    IEnumerator transitionToRankings()
    {
        yield return new WaitForSeconds(5);
        //TODO: change this to the Thanks for Playing scene.
        debugMasterMenuBehavior.goToPresetSceneForRelease("ap_newtitle");
    }

    void Update()
    {
        textToCapitalize.text = textToCapitalize.text.ToUpper();
    }
}
