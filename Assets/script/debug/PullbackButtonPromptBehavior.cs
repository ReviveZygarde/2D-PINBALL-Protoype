using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullbackButtonPromptBehavior : MonoBehaviour
{
    [SerializeField] private Launcher launcher;
    private SpriteRenderer sprr;
    [SerializeField] private bool activateSprite;

    // Start is called before the first frame update
    void Start()
    {
        sprr = GetComponent<SpriteRenderer>();
        StartCoroutine(flash());
    }

    IEnumerator flash()
    {
        while(launcher.isActive)
        {
            sprr.enabled = false;
            yield return new WaitForSecondsRealtime(0.5f);
            sprr.enabled = true;
            yield return new WaitForSecondsRealtime(0.5f);
        }
        while(launcher.isActive == false)
        {
            sprr.enabled = false;
            yield return new WaitForSecondsRealtime(0.5f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
