using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip presentSuccess;
    public AudioClip presentFail;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();     
    }

    void Update()
    {
        
    }

    public void playPresentSucess()
    {
        audio.PlayOneShot(presentSuccess);
    }

    public void playPresentFail()
    {
        audio.PlayOneShot(presentFail);
    }
}
