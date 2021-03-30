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

    public void dropPresent()
    {
        if (!presentOnCooldown)
        {
            //Instansiate ("Throw") present
            GameObject present = Instantiate(redPresent, presentSpawner.position, Quaternion.identity, presentSpawner);
            //Add a bit of random rotation to each throw
            present.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-.2f, .2f), ForceMode2D.Impulse);
            //Start cooldown
            presentOnCooldown = true;
        }
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
