using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Rhythm Program made by Mack Pearson-Muggli.
/// Used with permission.
/// </summary>

public class RhythmVisualizer : MonoBehaviour
{
    //[SerializeField]
    //GameObject imageObj, textObj;
    //Image image;
    //TMPro.TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    public Text rh_Status;
    public GameObject interrupt_rhStatusOK;
    public GameObject interrupt_rhStatusNG;
    public gameplayControlsBehavior pl_input;
    public scoreBehavior scoreComponent;
    public ModeBehavior modeComponent;

    void Start()
    {
        //image = imageObj.GetComponent<Image>();
        //textMeshPro = textObj.GetComponent<TMPro.TextMeshProUGUI>();
    }



    // Update is called once per frame
    void Update()
    {
        if (pl_input.lfIsHeld || pl_input.rfIsHeld)
        {
            if (RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "Good";
                interrupt_rhStatusOK.SetActive(true);
                interrupt_rhStatusNG.SetActive(false);
                scoreComponent.pl_score++;
                modeComponent.beatPressCount++;
            }
            if (!RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "Bad";
                interrupt_rhStatusNG.SetActive(true);
                interrupt_rhStatusOK.SetActive(false);
            }
        }
        if(!pl_input.lfIsHeld || !pl_input.rfIsHeld)
        {
            if (!RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "Bad";
                interrupt_rhStatusNG.SetActive(true);
                interrupt_rhStatusOK.SetActive(false);
            }
        }

        //changeSquareColor();
        /*else if (!SongPlayer.Instance.IsOnBeat())
        {
            image.color = Color.white;
        }*/
    }


    /*
    void changeSquareColor()
    {
        if (RhythmManager.Instance.IsOnBeat())
        {
            image.color = Color.green;
        }
        if (!RhythmManager.Instance.IsOnBeat())
        {
            image.color = Color.red;
        }
    }
    */
}