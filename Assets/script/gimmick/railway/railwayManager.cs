using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railwayManager : MonoBehaviour
{
    [SerializeField] private AudioSource SE_trainTracks;
    [SerializeField] private GameObject[] lines;
    [SerializeField] private int initializedTimeLeft = 15; //15 is the default value
    public int timeLeft;
    [SerializeField] private int currentIndexOfArray;
    [SerializeField] private GameObject pinball;
    public enum currentLine { INITIAL_STATE, Red, Pink, Blue }
    public currentLine train = currentLine.INITIAL_STATE;
    

    // Start is called before the first frame update
    void Start()
    {
        pinball = GameObject.Find("Pinball");
        timeLeft = initializedTimeLeft;
        changeLines();
    }

    IEnumerator countdownToLineChange()
    {
        while(timeLeft > 0)
        {
            timeLeft = timeLeft - 1; ;
            yield return new WaitForSeconds(1f);
        }
        yield return null;
        changeLines();
    }

    void changeLines()
    {
        //Debug.Log($"This is where index {lines[currentIndexOfArray]} is active.");
        SE_trainTracks.Play();
        foreach(GameObject lineObject in lines)
        {
            lineObject.SetActive(false);
        }
        if (currentIndexOfArray >= lines.Length)
        {
            currentIndexOfArray = 0;
            train = (currentLine)currentIndexOfArray;
        }
        lines[currentIndexOfArray].SetActive(true);
        currentIndexOfArray++;
        train = (currentLine)currentIndexOfArray;
        timeLeft = initializedTimeLeft;
        StartCoroutine(countdownToLineChange());
    }

    public void pauseTimer()
    {
        StopAllCoroutines();
    }

    public void resumeTimer()
    {
        StartCoroutine(countdownToLineChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
