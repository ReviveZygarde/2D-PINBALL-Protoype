using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionPlacementWhenKilled : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    private void OnEnable()
    {
        transform.position = target.position;
        StartCoroutine(switchLockonToBall());
    }

    //Pretty long method here.
    IEnumerator switchLockonToBall()
    {
        axisCopyY copyY = GameObject.Find("cam_LockonY").GetComponent<axisCopyY>(); //gets the component of the camera's AxisCopyY.
        GameObject pl_input = GameObject.Find("pl_input"); //Disables the player input temporarily
        GameObject originalLockonObject = copyY.objectToCopy_Y; //Saves the original locked-on object the camera focuses
        copyY.objectToCopy_Y = this.gameObject; //then replaces the locked-on object with this object
        pl_input.SetActive(false);
        Debug.Log($"camera lockon is {this.gameObject}");
        GameObject.Find("common").GetComponent<ModeBehavior>().pauseBossModeTimer(); //Pause the mode timer for 2 seconds, then resume it
        yield return new WaitForSeconds(2);
        GameObject.Find("common").GetComponent<ModeBehavior>().resumeBossModeTimer();
        copyY.objectToCopy_Y = originalLockonObject; //The original locked-on game object is whatever axisCopyY previusly had.
        Debug.Log($"camera lockon is back to {originalLockonObject}");
        pl_input.SetActive(true); //player input is re-enabled
        copyY.BallKilledByBoss(); //Camera moves to the ball with the SmoothDamp technique
    }
}
