using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Present : MonoBehaviour
{
    public Sprite[] presentTypeSprites;
    private DataManager.presentTypes presentType;

    public void setPresentType(DataManager.presentTypes _presentType)
    {
        presentType = _presentType;
        switch (presentType)
        {
            case DataManager.presentTypes.RED:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[0];
                break;
            case DataManager.presentTypes.GREEN:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[1];
                break;
            case DataManager.presentTypes.YELLOW:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[2];
                break;
            case DataManager.presentTypes.NAUGHTY:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[3];
                break;
            default:
                GetComponent<SpriteRenderer>().sprite = presentTypeSprites[0];
                break;
        }
    }

    public DataManager.presentTypes getPresentType()
    {
        return presentType;
    }
}
