namespace extraGame_AKB
{
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

//Got from the video https://www.youtube.com/watch?v=f3IYIvd-1mY

public partial class PlayerStateManager : MonoBehaviour


{
    #pragma warning disable 0414
    //Variables
    [SerializeField] BasketballHandler basketballHandler;
    public bool hasBall;
    public bool awayTeam;
    private int playerID;
    public Animator animator;
    private ThirdPersonController tpc;
    public PlayerInput pl_input;
    [SerializeField] private GameObject HomeOrAwayHoop;
    private CharacterController characterController;
    public bool isInSDarea;
    public int SpecialGaugeValue;
    public GameObject B_ButtonPrompt;
    public Slider SP_slider;
    public int SP_GaugeIncreaseValue;
    //public GameObject GO_Fire;
    //public GameObject GO_FireBall;
    private ParticleSystem FX_Fire;
    [SerializeField] private StarterAssetsInputs pl_sai;
    private bool RootMotionEnabled;

    /// <summary>
    /// Variables pertaining to auto movement for sp action
    /// </summary>
    private float Speed = 0.3f;
    //private float Xing;
    //private float Zing;
    /// end variables.

    public enum playerStatus
    { NORMAL, OFFENDED, IN_DEFENSE, SP_READY, IN_SP_ACTION, SP_DONE}
    public playerStatus status = playerStatus.NORMAL;


    private void Awake()
    {
        playerID = 0;
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        tpc = GetComponent<ThirdPersonController>();
        pl_input = GetComponent<PlayerInput>();
        //GO_FireBall = GameObject.Find("FX_FireBall");
        characterController = GetComponent<CharacterController>();
        B_ButtonPrompt = this.transform.Find("B_Button_Prompt").gameObject;
        //SP_slider = GameObject.Find("Special Meter").GetComponent<Slider>();
        B_ButtonPrompt.SetActive(false);
        //GO_FireBall.SetActive(false);
        //FX_Fire = GO_Fire.GetComponent<ParticleSystem>();
        pl_sai = GetComponent<StarterAssetsInputs>();
        SpecialGaugeValue = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        //GO_Fire.SetActive(false);

        if (!awayTeam)
        {
            HomeOrAwayHoop = GameObject.FindGameObjectWithTag("Home");
        }
        else
        {
            HomeOrAwayHoop = GameObject.FindGameObjectWithTag("Away");
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (SP_slider != null)
            {
                SP_slider.value = SpecialGaugeValue;
            }
            else
            {
                
                Debug.Log("SP_slider is null");
            }

        if (B_ButtonPrompt.activeSelf)
        {
            if(SpecialGaugeValue < 100)
            {
                B_ButtonPrompt.SetActive(false);
            }
        }

            if (SpecialGaugeValue >= 100)
            {
                //GO_Fire.SetActive(true);
                status = playerStatus.SP_READY;
                FX_Fire.Play();
                Debug.Log("AP DEBUG : THIS IS IT!!");
            }
            else
            {
                //FX_Fire.Stop();

            }

        if (RootMotionEnabled)
        {
            Vector3 position = transform.position;
            position.y = 2.54f;
        }
    }

    /*
    private void FixedUpdate()
    {
        if (status == playerStatus.IN_SP_ACTION)
        {
            transform.Translate(test_box.transform.position * Time.deltaTime * Speed);
            if(this.transform.position == test_box.transform.position)
            {
                status = playerStatus.SP_DONE;
            }
        }
    }
    */

    #region Actions

    public void ShootBall()
    {
        StartCoroutine(ShootAnim());
    }

    public void PauseGame()
    {
        GameObject PauseMenu = GameObject.Find("GAME UI");
        if (PauseMenu != null)
        {
            PauseMenu.GetComponent<MainMenuOptions>().PauseGame();
        }
        else 
        {
            Debug.Log("Pause Menu is not found...");
        }
        
    }

    public void StealBall()
    {
        //When the opponent wants to steal a ball from another, they take the ball immediately and push the opponent away.
        //To prevent the player that had the ball from obtaining the ball again the split second after they got pushed,
        //maybe have the collider of that player ignore the ball's collider for a set amount of time?
        Debug.Log("AP DEBUG: STEAL BUTTON has been pushed.");
        //Search for the player with the opponent's tag
        if (!hasBall)
        {
            StartCoroutine(tempDisableMovement());
            animator.Play("Offense_push"); //The code below causes the opponent to release the ball as they do the animation.
            
            if(basketballHandler.status == BasketballHandler.ballState.TAKEN)
            {
                if (this.tag == "Player")
                {
                    GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player2");
                    stealBallProcess(targetPlayer); //the local variable is passed to the method
                }
                if (this.tag == "Player2")
                {
                    GameObject targetPlayer = GameObject.FindGameObjectWithTag("Player");
                    stealBallProcess(targetPlayer);
                }
            }
            
        }
    }
    private void stealBallProcess(GameObject targetPlayer)
    {
        //this takes the local variable that was just now passed in and takes each component from that GameObject as needed.
        float distance = Vector3.Distance(targetPlayer.transform.position, transform.position);
        if (distance < 1.5)
        {
            Animator targetPlayer_anim = targetPlayer.GetComponent<Animator>();
            PlayerStateManager targetPlayer_psm = targetPlayer.GetComponent<PlayerStateManager>();
            if(targetPlayer_psm.status == playerStatus.IN_DEFENSE)
            {
                targetPlayer_psm.SpecialGaugeValue = targetPlayer_psm.SpecialGaugeValue + 5;
                return; //Returns immediately and the person who's defending the ball gets their SP gauge increased by 5. The player does not drop the ball.
            }
            targetPlayer_anim.Play("Fall");
            StartCoroutine(targetPlayer_psm.tempDisableMovementOnFall());
            targetPlayer_psm.hasBall = false;
            targetPlayer_anim.SetBool("hasBall", false);
            basketballHandler.ReleaseFromPlayerHand();
            if (targetPlayer_psm.status == playerStatus.SP_READY)
            {
                targetPlayer_psm.SpecialGaugeValue = 0;
                //If the opponent is in SP_READY status and gets Offended, their SP level goes to zero
                //and the status goes back to NORMAL state.
            }
            targetPlayer_psm.status = playerStatus.OFFENDED;
            SpecialGaugeValue = SpecialGaugeValue + (SP_GaugeIncreaseValue * 2);
            StartCoroutine(targetPlayer_psm.changePlayerStatusToNormal());
        }
    }

    IEnumerator changePlayerStatusToNormal()
    {
        yield return new WaitForSeconds(2f);
        status = playerStatus.NORMAL;
    }

    public void DefendBall()
    {
        //This is where "Guard frames" will apply and will allow the player to protect the ball from being stolen by the opponent.
        //There will be a set amount of time where "guard frames" will apply so the player will be invulnerable.
         Debug.Log("AP DEBUG: DEFENSE BUTTON has been pushed.");
         if(hasBall)
         {
             status = playerStatus.IN_DEFENSE;
             animator.Play("defend");
             basketballHandler.anim.enabled = false;
             basketballHandler.FindRightHand();
             basketballHandler.status = BasketballHandler.ballState.PROTECTED;
             StartCoroutine(tempDisableMovement());
         }
    }

    #endregion


    #region Animations


    public void StartRunningAnim()
    {
        animator.SetBool("isMoving", true);
    }

    public void StopRunningAnim()
    {
        animator.SetBool("isMoving", false);

    }

    //Shooting animation is a Coroutine to delay the animation transition
    IEnumerator ShootAnim()
    {
        if (animator.GetBool("hasBall"))
        {
            basketballHandler.anim.enabled = false;
            basketballHandler.ForceChangeParentToPlayerHand();
            pl_input.enabled = false; //Disables the player input completely for a set amount of time. This is so that the player character does not move unrealistically when they shoot. For now, this also disables pausing.
            animator.SetBool("isShooting", true);
            FaceHoop();
            StartCoroutine(tempDisableMovement());
            yield return new WaitForSeconds(0.3f);
            tpc.AllowJump = true; //Do not call JumpAction() as its already in the update. This bool variable can handle when the character jumps.
            yield return new WaitForSeconds(0.4f);
            animator.SetBool("hasBall", false);
            basketballHandler.ShootBall();
            yield return new WaitForSeconds(.8f);
            //shoot
            animator.SetBool("isShooting", false);
            pl_input.enabled = true;
            yield return new WaitForSeconds(.3f); //temporary bandaid fix. The coroutine is given 0.3 seconds to see if the player's
                                                  //animation state is still on "Shooting". If it is, then it will force the player
                                                  //to change the animation and if hasBall, relocates the ball to the player's
                                                  //hand.
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
            {
                if (animator.GetBool("hasBall"))
                {
                    animator.Play("Idle Dribble");
                    basketballHandler.FindRightHand();
                }
                if (!animator.GetBool("hasBall"))
                {
                    animator.Play("Idle");
                }
            }
        }
    }

    public void performSPAction()
    {
        if (isInSDarea && hasBall)
        {
            switch (status)
            {
                case playerStatus.SP_READY:
                    SpecialGaugeValue = 0;
                    status = playerStatus.IN_SP_ACTION;
                    FaceHoop();
                    float originalJumpHeight = tpc.JumpHeight;
                    tpc.JumpHeight = 4.5f;
                    tpc.AllowJump = true;
                    B_ButtonPrompt.SetActive(false);
                    StartCoroutine(SpAction_SlamDunk(originalJumpHeight));
                    break;
            }
        }
        return;
    }

    private void FaceHoop()
    {
        //Makes a LookAt at the basketball hoop, but only the Y axis is applied.
        Vector3 hoopPos = new Vector3(HomeOrAwayHoop.transform.position.x, transform.position.y, HomeOrAwayHoop.transform.position.z);
        this.transform.LookAt(hoopPos);
    }

    IEnumerator tempDisableMovement()
    {
        if(status != playerStatus.IN_DEFENSE)
        {
            animator.applyRootMotion = true; //this is to prevent the camera from skewing awkwardly when doing a defense.
            RootMotionEnabled = true;
        }
        pl_input.enabled = false;
        pl_sai.ForceMoveVectorToZero = true;
        yield return new WaitForSeconds(0.7f);
        pl_input.enabled = true;
        if(status == playerStatus.IN_DEFENSE)
        {
            status = playerStatus.NORMAL;
            basketballHandler.status = BasketballHandler.ballState.TAKEN;
            basketballHandler.anim.enabled = true;
        }
        animator.applyRootMotion = false;
        RootMotionEnabled = false;
        pl_sai.ForceMoveVectorToZero = false;
    }

    IEnumerator tempDisableMovementOnFall()
    {
        pl_input.enabled = false;
        pl_sai.ForceMoveVectorToZero = true;
        yield return new WaitForSeconds(1f);
        pl_input.enabled = true;
        pl_sai.ForceMoveVectorToZero = false;
    }

    IEnumerator SpAction_SlamDunk(float originalJumpHeight) //The slam dunk action. Original jump height's float value is passed in here.
    {
        basketballHandler.anim.enabled = false;
        basketballHandler.ForceChangeParentToPlayerHand();
        pl_input.enabled = false;
        pl_sai.ForceMoveVectorToZero = true;
        //GO_FireBall.SetActive(true);
        animator.Play("SP_SlamDunk1");
        yield return new WaitForSeconds(0.5f);
        basketballHandler.ShootBall();
        animator.SetBool("hasBall", false);
        yield return new WaitForSeconds(1f);
        if (characterController.isGrounded) //re-enables input once the character controller touches the ground.
        {
            pl_input.enabled = true;
        }
        tpc.JumpHeight = originalJumpHeight;
        //GO_FireBall.SetActive(false);
        status = playerStatus.NORMAL;
        pl_sai.ForceMoveVectorToZero = false;
    }

    #endregion


    #region Audio

    public void PlayFootSound()
    {

    }




    #endregion

}

}

