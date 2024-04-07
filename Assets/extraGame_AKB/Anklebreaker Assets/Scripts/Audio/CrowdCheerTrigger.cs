using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdCheerTrigger : MonoBehaviour
{
    [SerializeField] AudioSource CrowdCheerSound;
    private GameObject basketBall;
    void Start()
    {
        basketBall = GameObject.Find("Basketball Model");
    }

    // Update is called once per frame
    void Update()
    {
        BasketballHandler bh = basketBall.GetComponent<BasketballHandler>();
        if (bh.shotEntered == true) 
        {
            CrowdCheerSound.Play();
        }
    }
}
