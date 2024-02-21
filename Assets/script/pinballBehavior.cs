using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinballBehavior : MonoBehaviour
{
    //Empty script...
    //TODO: get information from a setting/game option singleton that tells the rigidbody mass?
    private Rigidbody2D ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        if(globalSetting.Instance.ballSetting == globalSetting.ballMass.LIGHT)
        {
            ballRigidbody.mass = ballRigidbody.mass - 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
