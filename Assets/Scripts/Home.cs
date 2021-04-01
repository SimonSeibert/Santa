using System;

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
    private DataManager.presentTypes presentTypeWish;

    private void Start()
    {
        //Get Random present Type
        Array values = Enum.GetValues(typeof(DataManager.presentTypes));
        System.Random random = new System.Random();
        presentTypeWish = (DataManager.presentTypes)values.GetValue(random.Next(values.Length));

        switch (presentTypeWish)
        {
            case DataManager.presentTypes.RED:
                presentTypeSprite.sprite = presentTypeSprites[0];
                break;
            case DataManager.presentTypes.GREEN:
                presentTypeSprite.sprite = presentTypeSprites[1];
                break;
            case DataManager.presentTypes.YELLOW:
                presentTypeSprite.sprite = presentTypeSprites[2];
                break;
            case DataManager.presentTypes.NAUGHTY:
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
                if (presentTypeWish == DataManager.presentTypes.NAUGHTY || presentTypeWish != collision.gameObject.GetComponent<Present>().getPresentType())
                {
                    DataManager.Instance.addScore(-1);
                }
                else
                {
                    DataManager.Instance.addScore(1);
                }
                scoreText.SetText(scoreMessage + DataManager.Instance.getCurrentScore());
                gotScore = true;
            }
        }
    }

}
