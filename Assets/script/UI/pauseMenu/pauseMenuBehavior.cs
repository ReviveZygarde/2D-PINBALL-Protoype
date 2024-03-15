using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pauseMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pl_input;
    private PlayerInput pauseInput;
    public GameObject pauseMenu;
    [SerializeField] private string sceneToExitTo;
    [SerializeField] private GameObject hintParent;

    void Start()
    {
        pauseInput = GetComponent<PlayerInput>();
        if(pauseMenu == null)
        {
            pauseMenu = this.gameObject;
        }
    }

    void OnEnable()
    {
        if (Gamepad.current != null)
        {
            Gamepad.current.PauseHaptics();
        }
    }

    void OnPauseHintToggle(InputValue value)
    {
        if (hintParent.activeSelf)
        {
            hintParent.SetActive(false);
        }
        else
        {
            hintParent.SetActive(true);
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
