using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashPanel : OverRampLayerChanger
{
    private Rigidbody2D pinballRigidbody;
    [SerializeField] private bool ballMagnet;

    /*
     * Inherited generic dash panel for the pinball when
     * it lands on it
     */

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        pinballRigidbody = Pinball.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            if (ballMagnet)
            {
                Pinball.transform.position = this.transform.position;
            }
            pinballRigidbody.velocity = ballDirection * velocityMultiplier;
        }
    }
}
