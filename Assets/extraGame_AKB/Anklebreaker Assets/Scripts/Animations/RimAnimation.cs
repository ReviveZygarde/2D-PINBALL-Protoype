using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimAnimation : MonoBehaviour
{
    public Animator animator;
    public bool isDunking;
    public GameObject fx_Sparks;
    public AudioSource sfx_Fireworks;


    private GameObject basketBall;
    private GameManager gameManager;
    //private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        basketBall = GameObject.Find("Basketball Model");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        fx_Sparks.SetActive(false);
        //player = 
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if the Player Has the ball.

        //Call Animator if Player Scores to Play animation.
        BasketballHandler bh = basketBall.GetComponent<BasketballHandler>();
        if (bh.shotEntered) 
        {
            StartCoroutine(PlayRegularAnimation());
        }
        if (gameManager.scoreP1 >= gameManager.gameScoreCap || gameManager.scoreP2 >= gameManager.gameScoreCap) 
        {
            fx_Sparks.SetActive(true);
            sfx_Fireworks.Play();
        
        }


        //Play Stealing Ball
        
    }

    IEnumerator PlayRegularAnimation() 
    {
        animator.SetBool("exitHoop", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("exitHoop", false);

    }
    IEnumerator PlayDunkAnimation() 
    {
        animator.SetBool("exitHoop", true);
        animator.SetBool("isDunking", true);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("exitHoop", false);
        animator.SetBool("isDunking", false);
    }
}
