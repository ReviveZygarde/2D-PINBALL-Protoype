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
        foreach (GameObject line in lines)
        {
            line.SetActive(false);
        }
        changeLines();
    }

    IEnumerator waitToChangeLines()
    {
        while(timeLeft > 0)
        {
            timeLeft--;
            yield return new WaitForSeconds(1f);
        }

        while (pinball.layer != 0)
        {
            yield return new WaitForSeconds(0.25f);
        }

        changeThenInitializeTime();
        yield return null;
    }

    void changeThenInitializeTime()
    {
        changeLines();
        timeLeft = initializedTimeLeft;
    }

    void changeLines()
    {
        StopAllCoroutines();
        lines[nextIndexOfArray].SetActive(true);
        nextIndexOfArray++;
        lines[nextIndexOfArray - 1].SetActive(false);
        if (nextIndexOfArray >= lines.Length)
        {
            nextIndexOfArray = 0;
        }
        StartCoroutine(waitToChangeLines());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}