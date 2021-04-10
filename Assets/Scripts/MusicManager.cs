using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip intro;
    public AudioClip loop;
    private new AudioSource audio;
    private float introTimer;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(intro);
        introTimer = intro.length;
    }

    void Update()
    {
        if (introTimer >= 0)
        {
            introTimer -= Time.deltaTime;
            if (introTimer < 0)
            {
                audio.clip = loop;
                audio.Play();
                audio.loop = true;
            }
        }
    }
}
