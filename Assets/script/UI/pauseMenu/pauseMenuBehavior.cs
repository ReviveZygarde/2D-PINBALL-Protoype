using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pl_input;
    public GameObject pauseMenu;
    [SerializeField] private string sceneToExitTo;

    void Start()
    {
        if(pauseMenu == null)
        {
            pauseMenu = this.gameObject;
        }
    }

    public void ResumeGame()
    {
        pl_input.SetActive(true);
        Time.timeScale = pl_input.GetComponent<gameplayControlsBehavior>().timescaleBeforePaused;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        globalScoreBehavior.Instance.global_pl_score = 0;
        AudioListener.pause = false;
        SceneManager.LoadScene(sceneToExitTo);
    }
}
