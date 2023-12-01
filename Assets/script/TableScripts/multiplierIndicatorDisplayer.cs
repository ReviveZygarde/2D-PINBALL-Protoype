using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class multiplierIndicatorDisplayer : MonoBehaviour
{
    /// <summary>
    /// Makes an array of GameObjects, and simply activates them
    /// in the Update depending on the multiplierState machine.
    /// Pretty simple I think.
    /// </summary>
    
    private scoreBehavior common_scoreBehavior;
    //private TextMesh textMeshDisplay;
    [SerializeField] private GameObject[] multiplierIndicators; //An array of GameObjects! I am not good at arrays...

    void Start()
    {
        GameObject common = GameObject.Find("common"); //Finds common, retrieves the ScoreBehavior component.
        common_scoreBehavior = common.GetComponent<scoreBehavior>();
        //textMeshDisplay = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if(common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X1)
        {
            foreach(GameObject indicator in multiplierIndicators)
            {
                indicator.SetActive(false);
            }
        }
        if (common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X2)
        {
            multiplierIndicators[0].SetActive(true);
        }
        if (common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X4)
        {
            multiplierIndicators[1].SetActive(true);
        }
        if (common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X6)
        {
            multiplierIndicators[2].SetActive(true);
        }
        if (common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X8)
        {
            multiplierIndicators[3].SetActive(true);
        }
        if (common_scoreBehavior.multiplierState == scoreBehavior.multiplier.X10)
        {
            multiplierIndicators[4].SetActive(true);
        }
        //textMeshDisplay.text = $"{common_scoreBehavior.multiplierState}";
    }
}
