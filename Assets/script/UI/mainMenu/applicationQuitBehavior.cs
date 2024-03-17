using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applicationQuitBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(quit());
    }

    IEnumerator quit()
    {
        yield return new WaitForSecondsRealtime(2f);
        Application.Quit();
    }
}
