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
    public gameplayControlsBehavior pl_input;
    public scoreBehavior scoreComponent;

    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (pl_input.lfIsHeld || pl_input.rfIsHeld)
        {
            if (RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "GOOD!";
                scoreComponent.pl_score++;
            }
            if (!RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "";
            }
        }
        if(!pl_input.lfIsHeld || !pl_input.rfIsHeld)
        {
            if (!RhythmManager.Instance.IsOnBeat())
            {
                rh_Status.text = "";
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