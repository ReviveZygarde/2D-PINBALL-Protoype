using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnableForRoulette : MonoBehaviour
{
    private GameObject Pinball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Pinball = GameObject.Find("Pinball");
        this.transform.position = Pinball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
