using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSoundCue : MonoBehaviour
{
    private Rigidbody rbody;
    private AudioSource ballGroundBounce;
    private MeshCollider Court;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        ballGroundBounce = GetComponent<AudioSource>();
        GameObject Court_gameObject = GameObject.Find("Court");
        Court = Court_gameObject.GetComponent<MeshCollider>();
    }

    private void OnCollisionEnter(Collision collision) //sound plays every time the ball touches the ground.
    {
        if(collision.collider == Court)
        {
            ballGroundBounce.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
