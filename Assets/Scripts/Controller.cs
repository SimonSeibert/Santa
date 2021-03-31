using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Objects")]
    public Transform presentSpawner;
    public GameObject redPresent;
    [Header("Stats")]
    public float presentCooldownTime = 1f;
    public float upAndDownSpeed = 2f;
    public float upAndDownHeight = 0.3f;
    public bool enableDropSpin = true;
    [Range(0f, .5f)]
    public float dropSpinRange = .2f;

    float presentCooldownTimer;
    bool presentOnCooldown = false;
    float upAndDownOffsetY;

    void Start()
    {
        presentCooldownTimer = presentCooldownTime;
        upAndDownOffsetY = transform.position.y;
    }

    void Update()
    {
        cooldownManagement();
        moveUpAndDown();
    }

    void dropPresent(DataManager.presentTypes presentType)
    {
        if (!presentOnCooldown)
        {
            //Instansiate ("Throw") present
            GameObject present = Instantiate(redPresent, presentSpawner.position, Quaternion.identity, presentSpawner);
            switch (presentType)
            {
                case DataManager.presentTypes.RED:
                    present.SendMessageUpwards("setPresentType", DataManager.presentTypes.RED);
                    break;
                case DataManager.presentTypes.GREEN:
                    present.SendMessageUpwards("setPresentType", DataManager.presentTypes.GREEN);
                    break;
                case DataManager.presentTypes.YELLOW:
                    present.SendMessageUpwards("setPresentType", DataManager.presentTypes.YELLOW);
                    break;
                //Naughty is useless right now as your not supposed to throw anything but maybe later you could add coal
                case DataManager.presentTypes.NAUGHTY:
                    present.SendMessageUpwards("setPresentType", DataManager.presentTypes.NAUGHTY);
                    break;
                default:
                    present.SendMessageUpwards("setPresentType", DataManager.presentTypes.RED);
                    break;
            }
            //Add a bit of random rotation to each throw
            if (enableDropSpin) present.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-dropSpinRange, dropSpinRange), ForceMode2D.Impulse);
            //Start cooldown
            presentOnCooldown = true;
        }
    }

    public void dropPresentRed()
    {
        dropPresent(DataManager.presentTypes.RED);
    }
    public void dropPresentGreen()
    {
        dropPresent(DataManager.presentTypes.GREEN);
    }
    public void dropPresentYellow()
    {
        dropPresent(DataManager.presentTypes.YELLOW);
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

    void moveUpAndDown()
    {
        Vector3 pos = transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * upAndDownSpeed);
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z) * upAndDownHeight + new Vector3(0, upAndDownOffsetY, 0);
    }
}
