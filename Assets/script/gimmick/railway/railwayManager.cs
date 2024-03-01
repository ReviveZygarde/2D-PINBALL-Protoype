using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railwayManager : MonoBehaviour
{
    [SerializeField] private GameObject[] lines;
    [SerializeField] private int initializedTimeLeft = 15; //15 is the default value
    [SerializeField] private int timeLeft;
    [SerializeField] private int currentIndexOfArray;
    [SerializeField] private GameObject pinball;
    

    // Start is called before the first frame update
    void Start()
    {
        pinball = GameObject.Find("Pinball");
        timeLeft = initializedTimeLeft;
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
            if (pinball.layer == 0)
            {
                changeThenInitializeTime();
            }
            yield return new WaitForSeconds(0.25f);
        }

        if (pinball.layer == 0)
        {
            changeThenInitializeTime();
        }
    }

    void changeThenInitializeTime()
    {
        changeLines();
        timeLeft = initializedTimeLeft;
    }

    void changeLines()
    {
        foreach(GameObject line in lines)
        {
            line.SetActive(false);
        }
        lines[currentIndexOfArray].SetActive(true);
        currentIndexOfArray++;
        if(currentIndexOfArray >= lines.Length)
        {
            currentIndexOfArray = 0;
        }
        StopAllCoroutines();
        StartCoroutine(waitToChangeLines());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
