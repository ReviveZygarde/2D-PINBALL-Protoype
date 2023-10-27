using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCollision : MonoBehaviour
{
    public  GameObject Pinball;
    public ModeBehavior common_modeBehavior;
    public Text uiStatusText;
    private int timesHit = 0;
    public int HP;


    // Start is called before the first frame update
    void Start()
    {
        //Pinball = GameObject.Find("Pinball");
        //common_modeBehavior = GameObject.Find("common").GetComponent<ModeBehavior>();
        //this.gameObject.SetActive(false); //Gets the required components, then disables itself.
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            timesHit++;
            //When the pinball hits the boss, it finds the UI_StatusText game object and takes the Text Component.
            uiStatusText = GameObject.Find("UI_statusText").GetComponent<Text>();
            if (timesHit >= HP)
            {
                uiStatusText.text = $"ALL RIGHT!! YOU DID IT!";
                timesHit = 0;
                this.gameObject.SetActive(false);
                common_modeBehavior.DetermineNextMultiplier();
            }
            else
            {
                uiStatusText.text = $"TAKE THAT!! {HP - timesHit} HITS LEFT!";
            }
        }
    }
}
