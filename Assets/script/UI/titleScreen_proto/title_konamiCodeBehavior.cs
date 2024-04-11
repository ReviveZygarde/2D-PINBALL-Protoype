using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class title_konamiCodeBehavior : MonoBehaviour
{
    //referenced code from a previous project that utilized the same thing:
    //https://github.com/MangoDragonHub/BasketBallProject/blob/main/ProjectAnkleBreaker_Unity/Assets/Anklebreaker%20Assets/Scripts/andrewp_controls/buttonSetting_forTitle.cs

    private List<string> konamiCodeInputs;
    private List<string> userButtonInputs;
    [SerializeField] private AudioSource successSound;
    private PlayerInput pl_input;

    private void Start()
    {
        pl_input = GetComponent<PlayerInput>();
        konamiCodeInputs = new List<string>() { "u", "u", "d", "d", "l", "r", "l", "r", "b", "a" };
        userButtonInputs = new List<string>();
    }
    void OnUp()
    {
        userButtonInputs.Add("u");
    }

    void OnDown()
    {
        userButtonInputs.Add("d");
    }

    void OnLeft()
    {
        userButtonInputs.Add("l");
    }

    void OnRight()
    {
        userButtonInputs.Add("r");
    }

    void OnAAction()
    {
        userButtonInputs.Add("a");
        checkListMatches();
    }

    void OnBAction()
    {
        userButtonInputs.Add("b");
    }

    private void checkListMatches()
    {
        if (userButtonInputs.SequenceEqual(konamiCodeInputs))
        {
            //play the success sound, turn on granny mode in the game manager.
            GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
            successSound.Play();
            Debug.Log("K O N A M I   C O D E   A C T I V A T E D .");
            globalSetting.Instance.hasEnteredKonamiCode = true;
        }

    }
}
