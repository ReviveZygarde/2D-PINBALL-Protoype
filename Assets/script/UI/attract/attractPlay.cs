using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attractPlay : MonoBehaviour
{
    private int seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitUntilPlayAttractVideo());
    }

    IEnumerator waitUntilPlayAttractVideo()
    {
        while(seconds < 10)
        {
            yield return new WaitForSeconds(1);
            seconds++;
        }
        if(seconds == 10)
        {
            SceneManager.LoadScene("attractScene");
        }
        yield return null;
    }
}
