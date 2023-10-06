using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumperBehavior : MonoBehaviour
{
    public tableTally tally;
    public Text statusText;

    private void Start()
    {
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tally.tallyBumper();
        StartCoroutine(changeStatusMessage());
    }

    IEnumerator changeStatusMessage()
    {
        statusText.text = "BUMP BUMP BUMP...";
        yield return new WaitForSeconds(1);
        statusText.text = "";
        yield return null;
    }
}
