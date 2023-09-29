using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class debug_RespawnBall : MonoBehaviour
{
    private GameObject Pinball;
    public GameObject PinballSpawnpoint;
    public GameObject launcherGate;
    public Launcher springLauncher;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.FindGameObjectWithTag("ball");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Once the pinball goes off the screen it goes back to the spawnpoint.
        Pinball.SetActive(false);
        launcherGate.SetActive(false); //Deactivates the Gate so the ball can get back in the big portion of the table.
        Pinball.transform.position = PinballSpawnpoint.transform.position;
        Pinball.SetActive(true);
        springLauncher.isActive = true; // Make the spring launcher usable again.
    }
}
