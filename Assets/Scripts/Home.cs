using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    public SpriteRenderer presentTypeSprite;
    public Sprite[] presentTypeSprites;
    public BoxCollider2D successCollider;
    public TextMeshProUGUI scoreText;

    private string scoreMessage = "Score: ";
    private bool gotScore = false;
    private string presentType;

    private void Start()
    {
        int randomPresentTypeIndex = Random.Range(0, Manager.Instance.getPresentTypes().Length);
        presentType = Manager.Instance.getPresentTypes()[randomPresentTypeIndex];
        switch (presentType)
        {
            case "red":
                presentTypeSprite.sprite = presentTypeSprites[0];
                break;
            case "green":
                presentTypeSprite.sprite = presentTypeSprites[1];
                break;
            case "yellow":
                presentTypeSprite.sprite = presentTypeSprites[2];
                break;
            case "naughty":
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
        if (collision.otherCollider == successCollider && !gotScore)
        {
            if (presentType == "naughty")
            {
                Manager.Instance.addScore(-1);
            }
            else
            {

                Manager.Instance.addScore(1);
            }
            scoreText.SetText(scoreMessage + Manager.Instance.getCurrentScore());
            gotScore = true;
        }
    }

}
