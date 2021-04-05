using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Present : MonoBehaviour
{
    public Sprite[] presentTypeSprites;
    public AudioSource hitAudio;
    public AudioSource successAudio;

    private Data.presentTypes presentType;
    private float soundCooldownTimer = .4f;
    private static float soundCooldown = .4f;
    private bool soundAllowed = true;


    private void Start()
    {
    }

    private void Update()
    {
        if (!soundAllowed)
        {
            soundCooldownTimer -= Time.deltaTime;
        }
        if (soundCooldownTimer <= 0)
        {
            soundCooldownTimer = soundCooldown;
            soundAllowed = true;
        }
    }

    public void setPresentType(Data.presentTypes _presentType)
    {
        presentType = _presentType;
        switch (presentType)
        {
            case Data.presentTypes.RED:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[0];
                break;
            case Data.presentTypes.GREEN:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[1];
                break;
            case Data.presentTypes.YELLOW:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[2];
                break;
            case Data.presentTypes.NAUGHTY:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[3];
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[0];
                break;
        }
    }

    public Data.presentTypes getPresentType()
    {
        return presentType;
    }

    public void playSuccess()
    {
        successAudio.PlayOneShot(successAudio.clip);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (soundAllowed)
        {
            hitAudio.PlayOneShot(hitAudio.clip);
            soundAllowed = false;
        }
    }
}
