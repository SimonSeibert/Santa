using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAfterHit : MonoBehaviour
{
    public float firstHitBounceMultiplier = 75f;
    //[Range(0f, 1f)]
    //public float bouncyness = .2f;
    //
    private bool hit = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hit)
        {
            rb.AddForce(Vector2.right * Data.Instance.getGameSpeed() * firstHitBounceMultiplier, ForceMode2D.Force);
            hit = true;
        }
    }

    private void Update()
    {
        if (hit)
        {
            transform.Translate(Vector2.left * Data.Instance.getGameSpeed() * Time.deltaTime, Space.World);
        }
    }
}
