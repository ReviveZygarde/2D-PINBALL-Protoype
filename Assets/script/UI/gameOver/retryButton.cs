using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class retryButton : MonoBehaviour
{
    public Button retry;

    // Start is called before the first frame update
    void Start()
    {
        retry.onClick.AddListener(retryGame);
    }

    void retryGame()
    {
        GameObject gl_score_toReset_object = GameObject.Find("GL_score");
        globalScoreBehavior gl_score = gl_score_toReset_object.GetComponent<globalScoreBehavior>();
        gl_score.global_pl_score = 0;
        SceneManager.LoadScene("TestTable");
    }
}
