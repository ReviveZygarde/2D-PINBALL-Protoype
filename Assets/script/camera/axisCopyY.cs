using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class axisCopyY : MonoBehaviour
{
    public GameObject objectToCopy_Y;
    [Tooltip("The GameObject you want the camera to lock onto when the Pinball is in Layer 9 (the Roulette collision layer). If not using using that layer, leave it blank.")]
    public GameObject objectToCopy_Y_Roulette;
    private bool ballKilledByBoss = false;
    //---------------- for SmoothDamp
    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    private float cameraLockPosition;

    public void BallKilledByBoss()
    {
        StartCoroutine(waitForBossKillToggle());
    }

    IEnumerator waitForBossKillToggle()
    {
        ballKilledByBoss = true;
        yield return new WaitForSeconds(0.75f);
        ballKilledByBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToCopy_Y.layer == 9 && objectToCopy_Y_Roulette != null)
        {
            //transform.position = new Vector2(this.transform.position.x, objectToCopy_Y_Roulette.transform.position.y);
            cameraLockPosition = Mathf.SmoothDamp(transform.position.y, objectToCopy_Y_Roulette.transform.position.y, ref yVelocity, smoothTime);
            transform.position = new Vector2(transform.position.x, cameraLockPosition);
        }
        else if(objectToCopy_Y.layer == 0 && ballKilledByBoss == true)
        {
            cameraLockPosition = Mathf.SmoothDamp(transform.position.y, objectToCopy_Y.transform.position.y, ref yVelocity, smoothTime);
            transform.position = new Vector2(transform.position.x, cameraLockPosition);
        }
        else
        {
            transform.position = new Vector2(this.transform.position.x, objectToCopy_Y.transform.position.y);
        }
    }
}
