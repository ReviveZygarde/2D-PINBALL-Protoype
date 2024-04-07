using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_sound : MonoBehaviour
{

    public AudioClip[] audio_clips;

    public AudioSource ball_ground_bound;

    private int recen_clip_num = 0;

    private int clip_num = 0;

    // Start is called before the first frame update
    void Start()
    {

        ball_ground_bound.clip = audio_clips[clip_num];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void activate_ball_sound()
    {
        get_sound();
    }

    private void find_next_audio_clip()
    {
        recen_clip_num = clip_num;
        clip_num = Random.Range(0, audio_clips.Length);

        if(clip_num == recen_clip_num)
        {
            if (clip_num != (audio_clips.Length - 1))
            {
                clip_num = clip_num + 1;
            }
            else
            {
                clip_num = 0;
            }
        }
    }

    private void get_sound()
    {
        find_next_audio_clip();
        ball_ground_bound.clip = audio_clips[clip_num];
        play_sound();
    }

    private void play_sound()
    {
        ball_ground_bound.Play();
    }

}
