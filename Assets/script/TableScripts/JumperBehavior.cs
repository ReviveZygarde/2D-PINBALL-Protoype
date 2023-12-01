using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumperBehavior : MonoBehaviour
{
    public tableTally tally;
    public Text statusText;
    [SerializeField] private GameObject NonHitChildSprite;
    [SerializeField] private GameObject OnHitChildSprite;

    private void Start()
    {
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tally.tallyBumper();
        StartCoroutine(spriteChange());
        StartCoroutine(changeStatusMessage());
    }

    public void forceJumperEffect()
    {
        StartCoroutine(spriteChange());
    }

    IEnumerator spriteChange() //change the sprites which are GameObjects. Simple enable/disable.
    {
        if(NonHitChildSprite != null && OnHitChildSprite != null) //if they are null leave it alone and dont get the console angry.
        {
            NonHitChildSprite.SetActive(false);
            OnHitChildSprite.SetActive(true);
            yield return new WaitForSecondsRealtime(0.05f);
            NonHitChildSprite.SetActive(true);
            OnHitChildSprite.SetActive(false);
        }
        yield return null;
    }

    IEnumerator changeStatusMessage()
    {
        statusText.text = "BUMP BUMP BUMP...";
        yield return new WaitForSeconds(1);
        statusText.text = "";
        yield return null;
    }
}
