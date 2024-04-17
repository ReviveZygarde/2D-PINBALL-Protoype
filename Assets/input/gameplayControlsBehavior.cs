using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/*
 * gameplayControlsBehavior is what handles the New Input System
 * and also tells the Left/Right flippers, the Plunger, and the
 * table shaking mechanism whether they should be activated
 * or not.
 */

public class gameplayControlsBehavior : MonoBehaviour
{
    private PlayerInput pl_input;
    private L_FlipControl leftFlipperJoint;
    private R_FlipControl rightFlipperJoint;
    public bool lfIsHeld;
    public bool rfIsHeld;
    public bool plungerActionIsHeld;
    private GameObject pinball;
    private Rigidbody2D pinballRigidbody;
    public bool canShake = true; //Leave this enabled by default.
    public bool currentlyShaking;

    //pause menu related
    public AudioSource pauseSound;
    public GameObject PauseMenu;
    [HideInInspector] public float timescaleBeforePaused;

    //Audio for the Flippers
    public AudioSource flipperSound;

    //for CINEMACHINE Camera Shake
    private CinemachineImpulseSource cameraShakeUp;
    private CinemachineImpulseSource cameraShakeLeft;
    private CinemachineImpulseSource cameraShakeRight;

    // Start is called before the first frame update
    void Start()
    {
        pl_input = GetComponent<PlayerInput>();
        //Gets the control scheme configuration State Machine from GL_Setting, and retroactively applies it to the pl_input
        //by appending the State Machine's state to the end of the "ControlType" string. (i.e. A = ControlTypeA, B = ControlTypeB, etc.)
        //If it can't find the globalSetting singleton (usually for testing), it will use w/e control type defined in the inspector, per scene.
        /* 2024/4/16
         * A playtester encountered a bug where the CurrentActionMap switches back to ControlTypeA, because it is the default action map.
         * SwitchCurrentActionMap() could not read what I told it to read, because the Default action map rules everything out and pl_input was.
         * trying to read THAT, not my desired string. So, I had to set the defaultActionMap to my desired string, and then SwitchCurrentActionMap()
         * to the the defaultActionMap. Now rhythm mode works properly on different control schemes than Type A! Yay!
         */
        pl_input.defaultActionMap = "ControlType" + globalSetting.Instance.Control_Type;
        pl_input.SwitchCurrentActionMap(pl_input.defaultActionMap);
        //Finds Gameobjects and obtains their Rigidbody for manipulation
        leftFlipperJoint = GameObject.Find("L_HingeJoint").GetComponent<L_FlipControl>();
        rightFlipperJoint = GameObject.Find("R_HingeJoint").GetComponent<R_FlipControl>();
        pinball = GameObject.Find("Pinball");
        pinballRigidbody = pinball.GetComponent<Rigidbody2D>();
        //for Cinemachine components
        cameraShakeUp = GameObject.Find("camShakeUp").GetComponent<CinemachineImpulseSource>();
        cameraShakeLeft = GameObject.Find("camShakeLeft").GetComponent<CinemachineImpulseSource>();
        cameraShakeRight = GameObject.Find("camShakeRight").GetComponent<CinemachineImpulseSource>();
    }

    void OnLeftFlipper(InputValue value)
    {
        lfIsHeld = value.isPressed;
        flipperSound.Play();
    }

    void OnRightFlipper(InputValue value)
    {
        rfIsHeld = value.isPressed;
        flipperSound.Play();
    }

    void OnPlungerPullAction(InputValue value)
    {
        plungerActionIsHeld = value.isPressed;
    }

    void OnPauseButton(InputValue value)
    {
        //Pause Menu-related
        AudioListener.pause = true;
        pauseSound.Play();
        PauseMenu.SetActive(true);
        timescaleBeforePaused = Time.timeScale;
        Time.timeScale = 0f;
        canShake = true;
        this.gameObject.SetActive(false);
    }

    /*
    private void defaultLFlipper()
    {
        
    }

    private void defaultRFlipper()
    {
        
    }
    */

    void OnBoardShake_Up(InputValue value)
    {
        if (canShake)
        {
            Debug.Log("Table shake UP!!");
            cameraShakeUp.GenerateImpulse();
            pinballRigidbody.velocity = pinballRigidbody.velocity + new Vector2(0, 5f); //Simply adds Velocity for a gentle push on the ball.
            StartCoroutine(DisableShake());
        }
    }

    void OnBoardShake_L(InputValue value)
    {
        if (canShake)
        {
            Debug.Log("Table shake LEFT!!");
            cameraShakeLeft.GenerateImpulse();
            pinballRigidbody.velocity = pinballRigidbody.velocity - new Vector2(5f, 0);
            StartCoroutine(DisableShake());
        }
    }

    void OnBoardShake_R(InputValue value)
    {
        if (canShake)
        {
            Debug.Log("Table shake RIGHT!!");
            cameraShakeRight.GenerateImpulse();
            pinballRigidbody.velocity = pinballRigidbody.velocity + new Vector2(5f, 0);
            StartCoroutine(DisableShake());
        }
    }

    IEnumerator DisableShake() //Temporarily disables a boolean so you cannot spam the table shake (and thus attempting to defy gravity)
    {
        currentlyShaking = true;
        canShake = false;
        yield return new WaitForSeconds(0.75f);
        canShake = true;
        currentlyShaking = false;
        yield return null;
    }

    //Debug Inputs
    /*
    void OnDebug_Exit(InputValue value)
    {
        Debug.Log("Scene exit...");
        SceneManager.LoadScene(0);
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (lfIsHeld)
        {
            leftFlipperJoint.isKeyPress = true;
        }
        if (rfIsHeld)
        {
            rightFlipperJoint.isKeyPress = true;
        }
        if (!lfIsHeld)
        {
            //defaultLFlipper();
            leftFlipperJoint.isKeyPress = false;
        }
        if (!rfIsHeld)
        {
            //defaultRFlipper();
            rightFlipperJoint.isKeyPress = false;
        }

        if(pinball.layer != 0 && pinball.layer != 9) //This is to prevent the ball from clipping through the OverRamp
        {
            canShake = false;
        }
    }
}
