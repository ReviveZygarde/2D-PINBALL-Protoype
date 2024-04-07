using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScoreBehavior : MonoBehaviour
{


    public AudioClip[] BasketballScore;
    public AudioClip[] BasketBallMissed;
    public AudioClip clip;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void PlaySoundScore()
    {
        source.clip = BasketballScore[AudioRand(BasketballScore)];
        //Debug.Log(source.clip);
        source.Play();
    }

   public void PlaySoundMissed()
    {
        source.clip = BasketballScore[AudioRand(BasketBallMissed)];
        //Debug.Log(source.clip);
        source.Play();
    }

    private int AudioRand(AudioClip[] tempSound)

    {
        int Random_Volume = 0;
        Random_Volume = Random.Range(0, tempSound.Length);
        return Random_Volume;
    }


}
