using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashPanel : OverRampLayerChanger
{
    private Rigidbody2D ballRigidbody;
    [SerializeField] private bool ballMagnet;

    /*
     * Inherited generic dash panel for the pinball when
     * it lands on it
     */

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        ballRigidbody = Pinball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            if (ballMagnet)
            {
                Pinball.transform.position = this.transform.position;
            }
            ballRigidbody.velocity = ballDirection * velocityMultiplier;
        }
    }
}
