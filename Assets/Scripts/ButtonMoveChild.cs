using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveChild : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float moveAmount = 10f;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Move Down
        foreach (Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y - moveAmount, child.position.z);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Move Back Up
        foreach (Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y + moveAmount, child.position.z);
        }
    }
}
