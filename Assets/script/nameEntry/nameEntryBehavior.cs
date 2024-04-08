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

    // Start is called before the first frame update
    void Start()
    {
        gl_scorekeep = globalScorekeep.Instance.GetComponent<globalScorekeep>();
        debugMasterMenuBehavior = GetComponent<debugMasterMenuBehavior>();
    }

    public void registerName(TMP_InputField inputtedText)
    {
        gl_scorekeep.names[gl_scorekeep.placeBeaten] = inputtedText.text;
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
            debugMasterMenuBehavior.goToPresetSceneForRelease("ap_newtitle");
        }
    }
}
