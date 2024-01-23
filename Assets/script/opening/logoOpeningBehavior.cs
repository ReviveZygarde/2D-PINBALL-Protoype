using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logoOpeningBehavior : MonoBehaviour
{
    private SpriteRenderer spr;
    [SerializeField] private int SceneToExitTo;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.enabled = false;
        StartCoroutine(showLogo());
    }

    IEnumerator showLogo()
    {
        yield return new WaitForSeconds(1);
        spr.enabled = true;
        yield return null;
        yield return new WaitForSeconds(5);
        exit();
    }

    void exit()
    {
        SceneManager.LoadScene(SceneToExitTo);
    }
}
