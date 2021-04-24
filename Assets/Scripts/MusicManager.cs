using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource loop;

    void Awake()
    {
        //Because scene would load another music object we need to destroy any music object except for one
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        intro.PlayOneShot(intro.clip);
        intro.loop = false;
        loop.PlayDelayed(intro.clip.length);
        loop.loop = true;
    }
}
