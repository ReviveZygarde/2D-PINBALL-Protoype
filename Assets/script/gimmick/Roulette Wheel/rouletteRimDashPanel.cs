using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteRimDashPanel : MonoBehaviour
{
    private Rigidbody2D pinballRigidbody;
    [SerializeField] private Vector2 dashDirection;
    private Vector2 originalDashDirection;
    public bool marker;
    public int markerPassCount;
    public int markerPassCountGoal;
    [Tooltip("Once the marker passCount reaches the passCountGoal, turns on the funnel so the ball lands on the wheel.")]
    public GameObject funnel;
    private float timerToActivateFunnel;
    public simpleRotate rotatingWheel;
    private GameObject pinball;
    private gameplayControlsBehavior pl_input;
    public GameObject shakePrompter;

    // Start is called before the first frame update
    void Start()
    {
        originalDashDirection = dashDirection;
        pinball = GameObject.Find("Pinball");
        pl_input = GameObject.Find("pl_input").GetComponent<gameplayControlsBehavior>();
        markerPassCountGoal = Random.Range(3, 10);
        pinballRigidbody = GameObject.Find("Pinball").GetComponent<Rigidbody2D>();
        if (marker)
        {
            funnel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Pinball")
        {
            pinballRigidbody.velocity = dashDirection;
            if (marker)
            {
                markerPassCount++;
                rotatingWheel.speed += 25;
                if (markerPassCount >= markerPassCountGoal)
                {
                    StartCoroutine(enableFunnels());
                }
            }
        }
    }

    private void Update()
    {
        if (marker && pinball.layer == 9)
        {
            if (pl_input.currentlyShaking && pinball)
            {
                markerPassCount = markerPassCountGoal;
                shakePrompter.SetActive(false);
                funnel.SetActive(true);
            }
            else if (pl_input.currentlyShaking == false)
            {
                return;
            }
        }
    }

    IEnumerator enableFunnels()
    {
        timerToActivateFunnel = Random.Range(1f, 3f);
        yield return new WaitForSeconds(timerToActivateFunnel);
        funnel.SetActive(true);
    }

    private void OnDisable()
    {
        //changes the marker pass count goal when it gets disabled, for next use.
        markerPassCountGoal = Random.Range(3, 10);
    }
}
