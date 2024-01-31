using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteManager : MonoBehaviour
{
    public rouletteTabBehavior[] rouletteTabChildren;
    private GameObject Pinball;
    public int waitBuffer;
    [SerializeField] private GameObject releaseMarker;
    [SerializeField] private rouletteReleaseMarkerBehavior releaseMarkerBehavior;
    [SerializeField] private float waitIncrementForReleaseMarker;
    [Tooltip("Specifies how long you want the Pinball to stay in the roulette wheel. This counts by frame. Recommended: 500.")]
    public int WaitBufferGoal;
    public float waitEntryCooldown;
    [SerializeField] private Vector2 directionToShoot;
    [SerializeField] private Rigidbody2D PinballRigidbody;
    [SerializeField] private GameObject CinemachineCopyYAxisToDisable;
    public GameObject rimDashPanelsParent;
    public simpleRotate rotationSpeedComponent;
    [SerializeField] private GameObject tableTrigger;
    [SerializeField] private gameplayControlsBehavior gameplayControlsBehavior;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        releaseMarker.SetActive(false);
    }

    public void initiateCoroutine()
    {
        CinemachineCopyYAxisToDisable.SetActive(false);
        StartCoroutine(CatchReleaseProcedure());
    }

    IEnumerator CatchReleaseProcedure()
    {
        //In the coroutine, I might have to use the array so
        //it gets all the rouletteTabs tagged Objects and make
        //the CanContactBall on all of them OFF.
        rimDashPanelsParent.SetActive(false);
        tableTrigger.SetActive(false);
        foreach(rouletteTabBehavior tab in rouletteTabChildren) //gets the array of the script and disables the CanContactPinball. See Update() in the referenced script.
        {
            tab.canContactPinball = false;
        }
        releaseMarker.SetActive(true); //Turns on the ReleaseMarker game object so the ball can collide with it.

        while (!releaseMarkerBehavior.isOKtoRelease) //Wait for the ReleaseMarker to give the OK to let go of the ball.
        {
            yield return new WaitForSeconds(waitIncrementForReleaseMarker);
        }
        if(releaseMarkerBehavior.isOKtoRelease) //Lets go of the pinball at the specified velocity.
        {
            foreach (rouletteTabBehavior tab in rouletteTabChildren)
            {
                tab.canHoldOntoPinball = false;
            }
            PinballRigidbody.velocity = directionToShoot;
            CinemachineCopyYAxisToDisable.SetActive(true);
            releaseMarker.SetActive(false);
            waitBuffer = 0; //wait buffer resets to 0 as release marker will be disabled for next use.
        }
        gameplayControlsBehavior.canShake = true;
        yield return new WaitForSeconds(waitEntryCooldown); //cooldown
        foreach (rouletteTabBehavior tab in rouletteTabChildren)
        {
            tab.reEnableCollider(); //re-enables the collider of the roulette tabs and CanContactPinball.
        }
        releaseMarkerBehavior.isOKtoRelease = false; //Turns OFF the bool so the ball doesnt get pushed out automatically when it contacts the Tab.
        rimDashPanelsParent.SetActive(true);
        rotationSpeedComponent.speed = rotationSpeedComponent.originalSpeed;
        tableTrigger.SetActive(true);
        yield return null;
    }



    // Update is called once per frame
    void Update()
    {
        if (releaseMarker.activeSelf == true)
        {
            waitBuffer++; //so the player can wait for the pinball to leave the roulette.
        }
    }
}
