using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funnelWallBehavior : MonoBehaviour
{
    public GameObject innerRimBarrier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pinball")
        {
            innerRimBarrier.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
