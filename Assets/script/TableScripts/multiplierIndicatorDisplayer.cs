using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplierIndicatorDisplayer : MonoBehaviour
{
    /// <summary>
    /// This is just a temporary/placeholder script for the sake of
    /// showing the player which Multiplier is in place. The final
    /// table will have actual sprites on the table that will show
    /// an activated/deactivated state, per multiplier light.
    /// Asthetic.
    /// </summary>
    
    private scoreBehavior common_scoreBehavior;
    private TextMesh textMeshDisplay;

    void Start()
    {
        GameObject common = GameObject.Find("common"); //Finds common, retrieves the ScoreBehavior component.
        common_scoreBehavior = common.GetComponent<scoreBehavior>();
        textMeshDisplay = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        textMeshDisplay.text = $"{common_scoreBehavior.multiplierState}";
    }
}
