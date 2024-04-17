using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
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
    [SerializeField] private Color lightbarColor;
    public scoreBehavior scoreComponent;

    [Tooltip("For the OnLeftFlipper() and OnRightFlipper(), they only work if you have the" +
        " PlayerInput component on the same GameObject this component is attached to." +
        " It will not work if you try to reference the PlayerInput from another GameObject.")]
    public PlayerInput rhythmVisualizer_pl_input;

    //For the OnLeftFlipper() and OnRightFlipper(), they only work if you have the PlayerInput
    //component on the same GameObject this component is attached to. It will not work if you
    //try to reference the PlayerInput from another GameObject.

    //[SerializeField] private JumperBehavior[] Jumpers;
    [SerializeField] private List<JumperBehavior> JumpersList;
    //A List of JumperBehaviors are needed because the GOOD! indicator will also make the jumpers do its collision effect.
    //2024/2/3 - I changed the array into a List because I have to dynamically empty and re-add gameObjects when things
    //like table layouts change during gameplay.

    [SerializeField] GameObject globalPostProcessEffector;


    void Start()
    {
        retrieveListOfBumpers();
        //see GameplayControlsBehavior.cs, line 49.
        rhythmVisualizer_pl_input.defaultActionMap = "ControlType" + globalSetting.Instance.Control_Type;
        rhythmVisualizer_pl_input.SwitchCurrentActionMap(rhythmVisualizer_pl_input.defaultActionMap);
    }

    void retrieveListOfBumpers()
    {
        GameObject[] UBumpers = GameObject.FindGameObjectsWithTag("UBumper");
        foreach (GameObject bumper in UBumpers)
        {
            JumpersList.Add(bumper.GetComponent<JumperBehavior>());
        }

        GameObject[] LBumpers = GameObject.FindGameObjectsWithTag("LBumper");
        foreach (GameObject bumper in LBumpers)
        {
            JumpersList.Add(bumper.GetComponent<JumperBehavior>());
        }
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
            if(Gamepad.current != null)
            {
                Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
            }
            rh_Status.text = "GOOD!";
            globalPostProcessEffector.SetActive(false);
            globalPostProcessEffector.SetActive(true);
            scoreComponent.pl_score = scoreComponent.pl_score + 20;
            //Make the jumpers change the sprite when you are OnBeat.
            foreach (JumperBehavior jumper in JumpersList)
            {
                if(jumper.isActiveAndEnabled == false) //if the script sees that the list has inactive GameObjects, it clears the list.
                {
                    JumpersList.Clear();
                }
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
            InputSystem.PauseHaptics();
            rh_Status.text = "";
       }

       if(JumpersList.Count == 0) //After the list is cleared and nothing is in it, the list has all the currently active GameObjects.
        {
            retrieveListOfBumpers();
        }

        //Ignore these lines of code below, they're leftovers from Beat Dash.

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