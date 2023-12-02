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
        globalScoreBehavior.Instance.global_pl_score = 0;
        SceneManager.LoadScene("TestTable");
    }
}
