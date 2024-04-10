using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class rankingPlacementStringRelay : MonoBehaviour
{
    private globalScorekeep rankings;
    private TextMeshProUGUI PlacementText;
    private int place;
    // Start is called before the first frame update
    void Start()
    {
        rankings = globalScorekeep.Instance.GetComponent<globalScorekeep>();
        PlacementText = GetComponent<TextMeshProUGUI>();
        determinePlace();
    }

    void determinePlace()
    {
        switch (rankings.placeBeaten)
        {
            case 0:
                PlacementText.text = "1st";
                break;
            case 1:
                PlacementText.text = "2nd";
                break;
            case 2:
                PlacementText.text = "3rd";
                break;
            default:
                place = rankings.placeBeaten + 1; //we +1 because the list is zero-based.
                PlacementText.text = $"{place}th";
                break;
        }
        appendPlaceString();
    }

    void appendPlaceString()
    {
        PlacementText.text = PlacementText.text + " Place";
    }
}
