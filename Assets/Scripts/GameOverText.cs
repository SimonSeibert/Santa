using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GameOverText : MonoBehaviour
{
    private TextMeshProUGUI gameOverText;

    void Start()
    {
        gameOverText = GetComponent<TextMeshProUGUI>();
        gameOverText.text = "Christmas is ruined! You delivered " + Data.Instance.getCurrentScore() + " out of 2.2 Billion presents!";
    }
}
