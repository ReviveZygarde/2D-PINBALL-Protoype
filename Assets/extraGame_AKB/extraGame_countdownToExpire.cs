namespace extraGame_AKB
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class extraGame_countdownToExpire : MonoBehaviour
{
    public int TimerInSeconds = 120;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countdownToSceneChange());
    }

    IEnumerator countdownToSceneChange()
    {
        while(TimerInSeconds > 0)
        {
            TimerInSeconds--;
            yield return new WaitForSecondsRealtime(1);
        }
        if(TimerInSeconds <= 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("extraGameEnd");
        }
    }
}

}

