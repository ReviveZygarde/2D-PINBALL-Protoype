using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shakePrompter : MonoBehaviour
{
    private SpriteRenderer spr;
    private GameObject pinball; 
    public rouletteRimDashPanel markerDashPanel;
    public GameObject objectToCopy_Y;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.enabled = false;
        objectToCopy_Y = GameObject.Find("Main Camera");
        pinball = GameObject.Find("Pinball");
        StartCoroutine(showPrompt());
    }

    private void OnEnable()
    {
        StartCoroutine(showPrompt());
    }

    IEnumerator showPrompt()
    {
        yield return new WaitForSeconds(3);

        while(markerDashPanel.markerPassCount <= markerDashPanel.markerPassCountGoal)
        {
            if(pinball.layer == 9)
            {
                spr.enabled = true;
                yield return new WaitForSeconds(0.5f);
                spr.enabled = false;
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(0.5f);
        }
        if(markerDashPanel.markerPassCount >= markerDashPanel.markerPassCountGoal)
        {
            spr.enabled = false;
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(this.transform.position.x, objectToCopy_Y.transform.position.y);
    }
}
