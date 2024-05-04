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
    [Tooltip("The GameObject that you want to enable/disable.")]
    [SerializeField] private GameObject childMesh;
    [SerializeField] private GameObject animationSpriteToDisable;
    [SerializeField] private GameObject bossDefeatSprite;
    private GameObject pl_input;
    private Collider2D bossColliderComponent;


    // Start is called before the first frame update
    void Start()
    {
        isDefeated = false;
        bossDefeatSprite.SetActive(false);
        splineAnim = GetComponent<SplineAnimate>();
        bossColliderComponent = GetComponent<Collider2D>();
        //pl_input = GameObject.Find("pl_input");
        //Pinball = GameObject.Find("Pinball");
        //common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        //this.gameObject.SetActive(false); //Gets the required components, then disables itself.
    }

    private void OnEnable()
    {
        if(bossColliderComponent != null)
        {
            bossColliderComponent.enabled = true;
        }
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
        pl_input = GameObject.Find("pl_input");
        pl_input.SetActive(false);
        isDefeated = true;
        bossDefeatSprite.SetActive(true);
        animationSpriteToDisable.SetActive(false);
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
        bossDefeatSprite.SetActive(false);
        animationSpriteToDisable.SetActive(true);
        pl_input.SetActive(true);
        this.gameObject.SetActive(false); //Game resumes.
        yield return null;
    }

    IEnumerator pauseMovement()
    {
        Collider2D collider = GetComponent<Collider2D>();
        splineAnim.Pause();
        collider.enabled = false;
        yield return new WaitForSecondsRealtime(1f); //2024/5/3: this was changed from 2 seconds based on playtesters' feedback
        splineAnim.Play();
        collider.enabled = true;
        hitEffectObject.SetActive(false);
        yield return null;
    }
}
