using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending_transition : MonoBehaviour
{
    public GameObject blackFadeIn;
    public string SceneJump;
    public float waitTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        yield return new WaitForSeconds(waitTimer);
        blackFadeIn.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneJump);
    }
}
