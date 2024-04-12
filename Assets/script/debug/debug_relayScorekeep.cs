using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debug_relayScorekeep : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text scoresText;
    [SerializeField] private Text statusText;

    private void OnEnable()
    {
        List<string> nameList = globalScorekeep.Instance.names;
        List<int> scoreList = globalScorekeep.Instance.scores;
        if (nameList == null && scoreList == null)
        {
            statusText.text = "SCORE KEEP is null.\nPlease clear.";
        }

        foreach (string name in nameList)
        {
            nameText.text = nameText.text + name + "\n";
        }

        
        foreach (int score in scoreList)
        {
            scoresText.text = scoresText.text + score + "\n";
        }
    }

    private void OnDisable()
    {
        nameText.text = "";
        scoresText.text = "";
    }

    public void tellScorekeepToClear()
    {
        globalScorekeep.Instance.clearRecords();
        statusText.text = "";
    }
}
