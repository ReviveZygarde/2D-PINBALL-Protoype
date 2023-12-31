using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class BossCollision : MonoBehaviour
{
    public  GameObject Pinball;
    public ModeBehavior common_modeBehavior;
    public Text uiStatusText;
    private int timesHit = 0;
    public int HP;
    public bool isDefeated;
    [SerializeField] private SplineAnimate splineAnim;
    [SerializeField] private CinemachineImpulseSource explosionImpulse;
    /// <summary>
    /// The variables below are for the Particles
    /// </summary>
    [SerializeField] private GameObject hitEffectObject;
    [SerializeField] private GameObject oneMoreHitEffectObject;
    [SerializeField] private GameObject winEffectObject;
    [SerializeField] private GameObject childMesh;


    // Start is called before the first frame update
    void Start()
    {
        isDefeated = false;
        //Pinball = GameObject.Find("Pinball");
        //common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        //this.gameObject.SetActive(false); //Gets the required components, then disables itself.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            timesHit++;
            hitEffectObject.SetActive(true);

            //Find the camShakeExplosion Game Object, and make the impulse signal to the cinemachine
            explosionImpulse.GenerateImpulseWithForce(4);

            //When the pinball hits the boss, it finds the UI_StatusText game object and takes the Text Component.
            uiStatusText = GameObject.Find("UI_statusText").GetComponent<Text>();
            if (timesHit >= HP)
            {
                StartCoroutine(explosionSequence());
            }
            else
            {
                uiStatusText.text = $"TAKE THAT!! {HP - timesHit} HITS LEFT!";
                if((HP - timesHit) == 1)
                {
                    oneMoreHitEffectObject.SetActive(true);
                }
                StartCoroutine(pauseMovement());
            }
        }
    }

    IEnumerator explosionSequence()
    {
        uiStatusText.text = $"ALL RIGHT!! YOU DID IT!";
        isDefeated = true;
        oneMoreHitEffectObject.SetActive(false);
        timesHit = 0;
        winEffectObject.SetActive(true);
        Pinball.gameObject.SetActive(false);
        splineAnim.Pause();
        common_modeBehavior.pauseTimers();
        yield return new WaitForSecondsRealtime(5); //Freezes the ball so the player can see the particle effect
        explosionImpulse.GenerateImpulseWithForce(5);
        //SpriteRenderer sprr = this.gameObject.GetComponent<SpriteRenderer>();
        //sprr.enabled = false;
        childMesh.SetActive(false);
        yield return new WaitForSecondsRealtime(3);
        Pinball.gameObject.SetActive(true);
        common_modeBehavior.DetermineNextMultiplier();
        isDefeated = false;
        //sprr.enabled = true;
        childMesh.SetActive(true);
        winEffectObject.SetActive(false);
        hitEffectObject.SetActive(false);
        splineAnim.Play();
        this.gameObject.SetActive(false); //Game resumes.
        yield return null;
    }

    IEnumerator pauseMovement()
    {
        Collider2D collider = GetComponent<Collider2D>();
        splineAnim.Pause();
        collider.enabled = false;
        yield return new WaitForSecondsRealtime(2);
        splineAnim.Play();
        collider.enabled = true;
        hitEffectObject.SetActive(false);
        yield return null;
    }
}
