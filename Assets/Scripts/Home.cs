using System;

using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    public SpriteRenderer presentTypeSprite;
    public Sprite[] presentTypeSprites;
    public BoxCollider2D successCollider;

    private bool gotScore = false;
    private Data.presentTypes presentTypeWish;
    private GameObject scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score_Manager");
        //Get Random present Type
        Array values = Enum.GetValues(typeof(Data.presentTypes));
        System.Random random = new System.Random();
        presentTypeWish = (Data.presentTypes)values.GetValue(random.Next(values.Length));

        switch (presentTypeWish)
        {
            case Data.presentTypes.RED:
                presentTypeSprite.sprite = presentTypeSprites[0];
                break;
            case Data.presentTypes.GREEN:
                presentTypeSprite.sprite = presentTypeSprites[1];
                break;
            case Data.presentTypes.YELLOW:
                presentTypeSprite.sprite = presentTypeSprites[2];
                break;
            case Data.presentTypes.NAUGHTY:
                presentTypeSprite.sprite = presentTypeSprites[3];
                break;
            default:
                presentTypeSprite.sprite = presentTypeSprites[0];
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Present landed in chimney
        if (collision.gameObject.tag == "Present")
        {
            if (collision.otherCollider == successCollider && !gotScore)
            {
                //Compare thrown present with the wish and adjust score accordingly
                if (presentTypeWish == Data.presentTypes.NAUGHTY || presentTypeWish != collision.gameObject.GetComponent<Present>().getPresentType())
                {
                    scoreManager.SendMessageUpwards("score", false);
                }
                else
                {
                    scoreManager.SendMessageUpwards("score", true);
                    collision.gameObject.SendMessageUpwards("playSuccess");
                }
                gotScore = true;
            }
        }
    }

    private void OnDestroy()
    {
        if (!gotScore && presentTypeWish != Data.presentTypes.NAUGHTY)
        {
            scoreManager.SendMessageUpwards("score", false);
        }
    }
}
