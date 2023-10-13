using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollision : MonoBehaviour
{
    public  GameObject Pinball;
    public ModeBehavior common_modeBehavior;
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
            if (timesHit >= HP)
            {
                timesHit = 0;
                this.gameObject.SetActive(false);
                common_modeBehavior.ScoreCalculate();
            }
        }
    }
}
