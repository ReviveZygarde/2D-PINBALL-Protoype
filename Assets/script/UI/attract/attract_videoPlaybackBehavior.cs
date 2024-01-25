using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class attract_videoPlaybackBehavior : MonoBehaviour
{
    private VideoPlayer video;
    [SerializeField] private PlayerInput pl_input;
    [SerializeField] private GameObject startButtonText;
    [Tooltip("Refer to Build Settings for scene index. Leaving this at 0 or a negative number will take the player to the title screen.")]
    [SerializeField] private int sceneToExitTo;

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        pl_input = GetComponent<PlayerInput>();
        StartCoroutine(showPrompt());
    }

    IEnumerator showPrompt()
    {
        while (!video.isPaused)
        {
            startButtonText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            startButtonText.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        yield return null;
    }

    void OnPauseButton()
    {
        video.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (video.isPaused)
        {
            if(sceneToExitTo <= 0)
            {
                SceneManager.LoadScene("TitlePrototype");
            }
            else
            {
                SceneManager.LoadScene(sceneToExitTo);
            }
        }
    }
}
