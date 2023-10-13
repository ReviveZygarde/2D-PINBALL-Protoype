using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trigChildBehavior : MonoBehaviour
{
    public bool didEnter;
    private SpriteRenderer spriteRender;

    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (didEnter)
        {
            spriteRender.enabled = true;
        }
        else
        {
            spriteRender.enabled = false;
        }
    }

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
