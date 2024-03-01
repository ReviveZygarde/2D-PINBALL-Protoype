using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railwayManager : MonoBehaviour
{
    [SerializeField] private GameObject[] lines;
    [SerializeField] private int initializedTimeLeft = 15; //15 is the default value
    [SerializeField] private int timeLeft;
    [SerializeField] private int nextIndexOfArray;
    [SerializeField] private GameObject pinball;
    

    // Start is called before the first frame update
    void Start()
    {
        pinball = GameObject.Find("Pinball");
        timeLeft = initializedTimeLeft;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
