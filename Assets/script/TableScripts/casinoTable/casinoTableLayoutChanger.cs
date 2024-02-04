using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casinoTableLayoutChanger : MonoBehaviour
{
    public GameObject[] greenLayout;
    public GameObject[] redLayout;
    public GameObject[] blackLayout;
    //been using arrays lately... Pretty good if you're manipulating multiple GameObjects.
    [HideInInspector] public string layoutColorParameter = "green";
    //"green" should always be the default value. It's hidden so you don't change it in the inspector.
    public GameObject specialVisualEffect;

    /*
    * Casino Table Layout Changer
    * Changes the "layout" of the table (GameObject)
    * depending on the state machine or string.
    */

    public void changeTableLayout()
    {
        if (layoutColorParameter == "green")
        {
            foreach(GameObject gameObject in greenLayout)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
