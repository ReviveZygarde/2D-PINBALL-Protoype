using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdAnimation : MonoBehaviour
{
    public Animator animator;
    private GameObject basketBall;

    // Start is called before the first frame update
    void Start()
    {
        basketBall = GameObject.Find("Basketball Model");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the Player Has the ball.

        //Call Animator if Player Scores to Play animation.
        BasketballHandler bh = basketBall.GetComponent<BasketballHandler>();
        if (bh.shotEntered) 
        {
            StartCoroutine(PlayAnimation());
        }
        //Play Stealing Ball
        
    }

    IEnumerator PlayAnimation() 
    {
        animator.SetTrigger("Scored");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.ResetTrigger("Scored");

    }
}
