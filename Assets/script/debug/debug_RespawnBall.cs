using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class debug_RespawnBall : MonoBehaviour
{
    private GameObject Pinball;
    public GameObject PinballSpawnpoint;
    [Tooltip("The GameObject to enable/disable once the PlungeGate trigger is touched. " +
        "This is to prevent the ball from re-entering the plunger shaft.")]
    public GameObject launcherGate;
    private Rigidbody2D ballRigidbody;
    [SerializeField] private GameObject blastEffect;
    public Launcher springLauncher;
    private ModeBehavior common_modeBehavior;
    private scoreBehavior common_scoreBehavior;
    private CinemachineImpulseSource camShakeBlast;
    public Text statusText;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.FindGameObjectWithTag("ball");
        common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        common_scoreBehavior = GameObject.Find("common").GetComponent<scoreBehavior>();
        statusText = GameObject.Find("UI_statusText").GetComponent<Text>();
        camShakeBlast = GameObject.Find("camShakeBlast").GetComponent<CinemachineImpulseSource>();
        ballRigidbody = Pinball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            Sequence();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Pinball)
        {
            Sequence();
        }
    }

    private void Sequence()
    {
        //Once the pinball goes off the screen it goes back to the spawnpoint.
        //Pinball.SetActive(false);
        launcherGate.SetActive(false); //Deactivates the Gate so the ball can get back in the big portion of the table.
        StartCoroutine(statusMessageChange());
        common_modeBehavior.consumeBall();
        Pinball.layer = 0; //if the ball was in any other collision layer, it resets back to 0.
        Pinball.transform.position = PinballSpawnpoint.transform.position;
        //Pinball.SetActive(true);
        //Disabling then re-enabling the Pinball gave errors, so I have it set to reposition the ball and change its velocity to zero.
        ballRigidbody.velocity = Vector2.zero;
        springLauncher.isActive = true; // Make the spring launcher usable again.
        camShakeBlast.GenerateImpulse();
        blastEffect.SetActive(false);
        blastEffect.SetActive(true);
    }

    IEnumerator statusMessageChange()
    {
        if (common_modeBehavior.ballSaverState == ModeBehavior.ballSaver.OFF)
        {
            statusText.text = "BOOOOO!";
            yield return new WaitForSeconds(2);
            statusText.text = $"{common_scoreBehavior.ballsLeft} BALL(S) LEFT!";
            yield return new WaitForSeconds(2);
            statusText.text = "GOOD LUCK!";
            yield return new WaitForSeconds(1);
            statusText.text = "";
        }
        else
        {
            statusText.text = "BALL SAVED";
            yield return new WaitForSeconds(1);
            statusText.text = "";
        }
        yield return null;
    }
}
