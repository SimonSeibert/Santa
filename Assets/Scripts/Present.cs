using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Present : MonoBehaviour
{
    public Sprite[] presentTypeSprites;
    public AudioSource hitAudio;
    public AudioSource successAudio;

    private Data.presentTypes presentType;

    private float hitSoundCooldownTimer = .4f;
    private static float hitSoundCooldown = .4f;
    private bool hitSoundAllowed = true;
    private int howManyHitSoundsAllowed = 2;


    private void Start()
    {

    }

    private void Update()
    {
        if (!hitSoundAllowed)
        {
            hitSoundCooldownTimer -= Time.deltaTime;
        }
        if (hitSoundCooldownTimer <= 0 && howManyHitSoundsAllowed > 0)
        {
            hitSoundCooldownTimer = hitSoundCooldown;
            hitSoundAllowed = true;
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
        if (hitSoundAllowed)
        {
            hitAudio.PlayOneShot(hitAudio.clip);
            howManyHitSoundsAllowed--;
            hitSoundAllowed = false;
        }
    }
}
