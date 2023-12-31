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
    public GameObject launcherGate;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Once the pinball goes off the screen it goes back to the spawnpoint.
        Pinball.SetActive(false);
        launcherGate.SetActive(false); //Deactivates the Gate so the ball can get back in the big portion of the table.
        StartCoroutine(statusMessageChange());
        common_modeBehavior.consumeBall();
        Pinball.transform.position = PinballSpawnpoint.transform.position;
        Pinball.SetActive(true);
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
