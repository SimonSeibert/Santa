using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Present : MonoBehaviour
{
    public Sprite[] presentTypeSprites;
    private Data.presentTypes presentType;

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
}
