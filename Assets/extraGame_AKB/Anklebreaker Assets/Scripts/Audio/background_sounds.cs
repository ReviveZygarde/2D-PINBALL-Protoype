using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_sounds : MonoBehaviour
{

    public AudioClip[] audio_background_clips;

    public AudioSource background_sound_source;

    private int clip_num = 0;

    private int recen_clip_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        background_sound_source.clip = audio_background_clips[clip_num];
        Invoke("Next_music", (background_sound_source.clip.length));
        play_sound();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Next_music()
    {
        clip_num = Random.Range(0, audio_background_clips.Length);
        if(clip_num == recen_clip_num)
        {
            if(clip_num >= (audio_background_clips.Length - 1))
            {
                clip_num = 0;
            }
            else
            {
                clip_num = clip_num + 1;
            }
            background_sound_source.clip = audio_background_clips[clip_num];
            Invoke("Next_music", (background_sound_source.clip.length));
            play_sound();
            recen_clip_num = clip_num;
        }
        else
        {
            background_sound_source.clip = audio_background_clips[clip_num];
            Invoke("Next_music", (background_sound_source.clip.length));
            play_sound();
            recen_clip_num = clip_num;
        }
    }

    private void play_sound()
    {
        background_sound_source.Play();
    }
}
