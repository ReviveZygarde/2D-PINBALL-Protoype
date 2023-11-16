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

            //Find the camShakeExplosion Game Object, and make the impulse signal to the cinemachine
            GameObject camShakeExplosionObject = GameObject.Find("camShakeExplosion");
            CinemachineImpulseSource explosionImpulse = camShakeExplosionObject.GetComponent<CinemachineImpulseSource>();
            explosionImpulse.GenerateImpulse();

            //When the pinball hits the boss, it finds the UI_StatusText game object and takes the Text Component.
            uiStatusText = GameObject.Find("UI_statusText").GetComponent<Text>();
            if (timesHit >= HP)
            {
                uiStatusText.text = $"ALL RIGHT!! YOU DID IT!";
                isDefeated = true;
                timesHit = 0;
                this.gameObject.SetActive(false);
                common_modeBehavior.DetermineNextMultiplier();
                isDefeated = false;
            }
            else
            {
                uiStatusText.text = $"TAKE THAT!! {HP - timesHit} HITS LEFT!";
                StartCoroutine(pauseMovement());
            }
        }
    }

    IEnumerator pauseMovement()
    {
        SplineAnimate splineAnim = GetComponent<SplineAnimate>();
        Collider2D collider = GetComponent<Collider2D>();
        splineAnim.Pause();
        collider.enabled = false;
        yield return new WaitForSecondsRealtime(2);
        splineAnim.Play();
        collider.enabled = true;
        yield return null;
    }
}
