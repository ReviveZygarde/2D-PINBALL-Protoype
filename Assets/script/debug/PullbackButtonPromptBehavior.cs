using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullbackButtonPromptBehavior : MonoBehaviour
{
    [SerializeField] private Launcher launcher;
    private SpriteRenderer sprr;
    [SerializeField] private int updateNum;
    private AudioSource notifySound;
    private bool firstTime; //boolean that is only true when the level as started, to notify the player they must pullback the plunger.

    // Start is called before the first frame update
    void Start()
    {
        sprr = GetComponent<SpriteRenderer>();
        notifySound = GetComponent<AudioSource>();
        firstTime = true;
        StartCoroutine(flash());
    }

    IEnumerator flash()
    {
        while(launcher.isActive)
        {
            sprr.enabled = false;
            yield return new WaitForSeconds(0.5f);
            sprr.enabled = true;
            if (firstTime)
            {
                notifySound.Play();
            }
            yield return new WaitForSeconds(0.5f);
        }
        if(launcher.isActive == false)
        {
            sprr.enabled = false;
            updateNum = 0;
            firstTime = false;
        }
        //yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (launcher.isActive)
        {
            updateNum++;
            if(updateNum == 1)
            {
                StartCoroutine(flash());
            }
        }
        if (!launcher.isActive)
        {
            sprr.enabled = false;
            notifySound.Stop();
        }
    }
}
