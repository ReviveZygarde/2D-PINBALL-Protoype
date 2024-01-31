using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteLayerChanger : MonoBehaviour
{
    public GameObject Pinball;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Pinball)
        {
            Pinball.layer = 9;
        }
    }
}
