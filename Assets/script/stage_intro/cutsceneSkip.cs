using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class cutsceneSkip : MonoBehaviour
{
    private PlayerInput pl_input;
    public GameObject effectsSequenceToStart;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
    }

    void OnPauseButton()
    {
        StartCoroutine(sceneSkip());
    }

    IEnumerator sceneSkip()
    {
        effectsSequenceToStart.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
