using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigChildBehavior : MonoBehaviour
{
    public bool didEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.Find("Pinball"))
        {
            didEnter = true;
            StartCoroutine(timerTillFalse());
        }
    }

    IEnumerator timerTillFalse()
    {
        yield return new WaitForSeconds(1);
        didEnter = false;
        yield return null;
    }
}
