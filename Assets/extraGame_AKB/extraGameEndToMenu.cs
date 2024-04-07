namespace extraGame_AKB
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class extraGameEndToMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectTransition;
    [SerializeField] private string sceneJump;

    // Start is called before the first frame updat
    void Start()
    {
        StartCoroutine(transitionToNextScene());
    }

    IEnumerator transitionToNextScene()
    {
        yield return new WaitForSeconds(4);
        gameObjectTransition.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneJump);
    }
}

}

