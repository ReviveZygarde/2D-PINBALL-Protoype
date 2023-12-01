using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public scoreBehavior scoreComponent;

    [Tooltip("For the OnLeftFlipper() and OnRightFlipper(), they only work if you have the" +
        " PlayerInput component on the same GameObject this component is attached to." +
        " It will not work if you try to reference the PlayerInput from another GameObject.")]
    public PlayerInput rhythmVisualizer_pl_input;

    //For the OnLeftFlipper() and OnRightFlipper(), they only work if you have the PlayerInput
    //component on the same GameObject this component is attached to. It will not work if you
    //try to reference the PlayerInput from another GameObject.

    [SerializeField] private JumperBehavior[] Jumpers;
    //An array of JumperBehaviors are needed because the GOOD! indicator will also make the jumpers do its collision effect

    void Start()
    {

    }

    void OnLeftFlipper(InputValue value)
    {
        checkOnBeat();
    }

    void OnRightFlipper(InputValue value)
    {
        checkOnBeat();
    }

    void checkOnBeat()
    {
        if (RhythmManager.Instance.IsOnBeat())
        {
            rh_Status.text = "GOOD!";
            scoreComponent.pl_score = scoreComponent.pl_score + 20;

            foreach (JumperBehavior jumper in Jumpers)
            {
                jumper.forceJumperEffect();
            }
        }
        if (!RhythmManager.Instance.IsOnBeat())
        {
            rh_Status.text = "";
        }
    }



    // Update is called once per frame
    void Update()
    {
       if (!RhythmManager.Instance.IsOnBeat())
       {
          rh_Status.text = "";
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