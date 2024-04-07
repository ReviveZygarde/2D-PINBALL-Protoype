using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttachPointChecker : MonoBehaviour
{
    public PlayerStateManager opponent_psm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            //Checks if the transform has a child. If it does, it checks if the opponent has the HasBall is true if its not supposed to.
            //This will change the variable back to false for them so the ball doesnt get teleported.
            if (opponent_psm.hasBall)
            {
                opponent_psm.hasBall = false;
                opponent_psm.animator.SetBool("hasBall", false);
            }
        }
    }
}