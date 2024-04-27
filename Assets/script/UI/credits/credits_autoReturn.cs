using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits_autoReturn : MonoBehaviour
{
    public int waitTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTimer);
        SendMessage("OnPauseButton");
    }
}
