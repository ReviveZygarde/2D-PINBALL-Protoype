using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    public Text score;
    private PlayerInput pl_input;
    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
        if(score != null && globalScoreBehavior.Instance != null)
        {
            score.text = $"{globalScoreBehavior.Instance.global_pl_score}";
        }
    }

    void OnPauseButton()
    {
        SceneManager.LoadScene("TestTable");
        globalScoreBehavior.Instance.global_pl_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
