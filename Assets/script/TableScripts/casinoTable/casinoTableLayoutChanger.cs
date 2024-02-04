using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;

public class casinoTableLayoutChanger : MonoBehaviour
{
    //been using arrays lately... Pretty good if you're manipulating multiple GameObjects.
    public GameObject[] greenLayout;
    public GameObject[] redLayout;
    public GameObject[] blackLayout;

    //"green" should always be the default value. It's hidden so you don't change it in the inspector.
    [HideInInspector] public string layoutColorParameter = "green";
    
    //En/disable the Greenscreen FMV when the table layout changes.
    public GameObject specialVisualEffect;

    //Optional: below variable and all commented out lines associated are
    //for changing the Dualshock4/Dualsense lightbar colors corresponding to the layout.
    //private DualShockGamepad gamepad;

    /*
    * Casino Table Layout Changer
    * Changes the "layout" of the table (GameObject)
    * depending on the state machine or string.
    */

    public void changeTableLayout()
    {
        if (layoutColorParameter == "green")
        {
            //gamepad.SetLightBarColor(Color.green);
            foreach (GameObject gameObject in greenLayout)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in redLayout)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in blackLayout)
            {
                gameObject.SetActive(false);
            }
        }
        if (layoutColorParameter == "red")
        {
            //gamepad.SetLightBarColor(Color.red);
            foreach (GameObject gameObject in greenLayout)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in redLayout)
            {
                gameObject.SetActive(true);
            }
            foreach (GameObject gameObject in blackLayout)
            {
                gameObject.SetActive(false);
            }
        }
        if (layoutColorParameter == "black")
        {
            //gamepad.SetLightBarColor(Color.white);
            foreach (GameObject gameObject in greenLayout)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in redLayout)
            {
                gameObject.SetActive(false);
            }
            foreach (GameObject gameObject in blackLayout)
            {
                gameObject.SetActive(true);
            }
        }
        if(specialVisualEffect != null)
        {
            specialVisualEffect.SetActive(false);
            specialVisualEffect.SetActive(true);
        }
    }  

    // Start is called before the first frame update
    void Start()
    {
        //gamepad = (DualShockGamepad)Gamepad.all[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
