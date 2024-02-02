using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSpriteAnimationManager : MonoBehaviour
{
    [SerializeField] private GameObject NE;
    [SerializeField] private GameObject SE;
    [SerializeField] private GameObject SW;
    [SerializeField] private GameObject NW;
    private Rigidbody2D entityRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //this is some yanderedev type beat coding and I hate it.
    {
        if(entityRigidbody.velocity.x > 1 && entityRigidbody.velocity.y > 1) //(1,1) NE isometric animation
        {
            NE.SetActive(true);
            SE.SetActive(false);
            SW.SetActive(false);
            NW.SetActive(false);
        }
        if(entityRigidbody.velocity.x > 1 && entityRigidbody.velocity.y < -1) //(1,-1) SE isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(true);
            SW.SetActive(false);
            NW.SetActive(false);
        }
        if (entityRigidbody.velocity.x < -1 && entityRigidbody.velocity.y < -1) //(-1,-1) SW isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(true);
            NW.SetActive(false);
        }
        if (entityRigidbody.velocity.x < -1 && entityRigidbody.velocity.y > 1) //(-1,1) NW isometric animation
        {
            NE.SetActive(false);
            SE.SetActive(false);
            SW.SetActive(false);
            NW.SetActive(true);
        }
    }
}
