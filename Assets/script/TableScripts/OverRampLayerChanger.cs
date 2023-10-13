using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverRampLayerChanger : MonoBehaviour
{
    public GameObject Pinball;
    public bool isEntrance;
    public bool isExit;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == Pinball)
        {
            if (isEntrance)
            {
                Pinball.layer = 6;
            }
            if (isExit)
            {
                Pinball.layer = 0;
            }
        }
    }
}
