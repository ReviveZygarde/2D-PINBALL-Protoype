using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class debug_RespawnBall : MonoBehaviour
{
    private GameObject Pinball;
    public GameObject PinballSpawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.FindGameObjectWithTag("ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Once the pinball goes off the screen it goes back to the spawnpoint.
        Pinball.SetActive(false);
        Pinball.transform.position = PinballSpawnpoint.transform.position;
        Pinball.SetActive(true);
    }
}
