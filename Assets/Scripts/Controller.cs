using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Objects")]
    public Transform presentSpawner;
    public GameObject present;
    public Animator animator;
    [Header("Stats")]
    public float presentCooldownTime = 1f;

    public bool enableDropSpin = true;
    [Range(0f, .5f)]
    public float dropSpinRange = .2f;

    private float presentCooldownTimer;
    private bool presentOnCooldown = false;

    void Start()
    {
        presentCooldownTimer = presentCooldownTime;
    }

    void Update()
    {
        cooldownManagement();
    }

    void dropPresent(Data.presentTypes presentType)
    {
        if (!presentOnCooldown)
        {
            //Play Animation
            animator.SetBool("isThrowing", true);
            StartCoroutine("stopThrowAnimation");
            //Instansiate ("Throw") present
            GameObject tmp = Instantiate(present, presentSpawner.position, Quaternion.identity, presentSpawner);
            switch (presentType)
            {
                case Data.presentTypes.RED:
                    tmp.SendMessageUpwards("setPresentType", Data.presentTypes.RED);
                    break;
                case Data.presentTypes.GREEN:
                    tmp.SendMessageUpwards("setPresentType", Data.presentTypes.GREEN);
                    break;
                case Data.presentTypes.YELLOW:
                    tmp.SendMessageUpwards("setPresentType", Data.presentTypes.YELLOW);
                    break;
                //Naughty is useless right now as your not supposed to throw anything but maybe later you could add coal
                case Data.presentTypes.NAUGHTY:
                    tmp.SendMessageUpwards("setPresentType", Data.presentTypes.NAUGHTY);
                    break;
                default:
                    tmp.SendMessageUpwards("setPresentType", Data.presentTypes.RED);
                    break;
            }
            //Add a bit of random rotation to each throw
            if (enableDropSpin) tmp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-dropSpinRange, dropSpinRange), ForceMode2D.Impulse);
            //Start cooldown
            presentOnCooldown = true;
        }
    }

    IEnumerator stopThrowAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("isThrowing", false);
    }

    public void dropPresentRed()
    {
        dropPresent(Data.presentTypes.RED);
    }
    public void dropPresentGreen()
    {
        dropPresent(Data.presentTypes.GREEN);
    }
    public void dropPresentYellow()
    {
        dropPresent(Data.presentTypes.YELLOW);
    }

    void cooldownManagement()
    {
        if (presentCooldownTimer > 0 && presentOnCooldown)
        {
            presentCooldownTimer -= Time.deltaTime;
        }
        if (presentCooldownTimer <= 0 && presentOnCooldown)
        {
            presentOnCooldown = false;
            presentCooldownTimer = presentCooldownTime;
        }
    }
}
