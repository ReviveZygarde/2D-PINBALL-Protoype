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

    // Start is called before the first frame update
    void Start()
    {
        originalDashDirection = dashDirection;
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
