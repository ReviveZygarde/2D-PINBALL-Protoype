using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteManager : MonoBehaviour
{
    public rouletteTabBehavior[] rouletteTabChildren;
    private GameObject Pinball;
    [SerializeField] private int waitBuffer;
    [SerializeField] private GameObject releaseMarker;

    // Start is called before the first frame update
    void Start()
    {
        Pinball = GameObject.Find("Pinball");
        releaseMarker.SetActive(false);
    }

    public void initiateCoroutine()
    {
        StartCoroutine(CatchReleaseProcedure());
    }

    IEnumerator CatchReleaseProcedure()
    {
        //In the coroutine, I might have to use the array so
        //it gets all the rouletteTabs tagged Objects and make
        //the CanContactBall on all of them OFF.
        foreach(rouletteTabBehavior tab in rouletteTabChildren)
        {
            tab.canContactPinball = false;
        }
        while(waitBuffer <= 200)
        {
            yield return new WaitForSeconds(1);
        }
        if(waitBuffer >= 200)
        {
            releaseMarker.SetActive(true);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (releaseMarker.activeSelf == true)
        {
            waitBuffer++;
        }
    }
}
