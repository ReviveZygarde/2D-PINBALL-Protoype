using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinballBehavior : MonoBehaviour
{
    private Rigidbody2D ballRigidbody;
    [SerializeField] private bool hasShadow;
    [SerializeField] private GameObject ballShadow;
    [SerializeField] private GameObject effectsChild;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        //get information from GL_Setting that tells the ball its rigidbody mass
        switch (globalSetting.Instance.ballSetting)
        {
            case globalSetting.ballMass.NORMAL:
                break;
            case globalSetting.ballMass.LIGHT:
                ballRigidbody.mass = ballRigidbody.mass - 1f;
                break;
            case globalSetting.ballMass.HEAVY:
                ballRigidbody.mass = ballRigidbody.mass + 1f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasShadow)
        {
            if (this.gameObject.layer == 0 || this.gameObject.layer == 9)
            {
                ballShadow.SetActive(false);
                effectsChild.SetActive(false);
            }
            else
            {
                ballShadow.SetActive(true);
                effectsChild.SetActive(true);
            }
        }
    }
}
