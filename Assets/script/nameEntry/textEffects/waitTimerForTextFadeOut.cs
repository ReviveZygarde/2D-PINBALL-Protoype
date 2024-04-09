using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitTimerForTextFadeOut : MonoBehaviour
{
    [SerializeField] private List<textFadeOutEffect> TextObjects;
    [SerializeField] private int waitTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForAction());
    }

    IEnumerator waitForAction()
    {
        yield return new WaitForSeconds(waitTimer);
        foreach(textFadeOutEffect effect in TextObjects)
        {
            effect.enabled = true;
        }
    }
}
