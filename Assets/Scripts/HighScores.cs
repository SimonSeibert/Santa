using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;
    private List<int> scoresList;
    private string prefPrequel = "HighScore";

    void OnEnable()
    {
        refreshHighScoreTexts();
    }

    private void refreshHighScoreTexts()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + ": " + PlayerPrefs.GetInt(prefPrequel + i);
        }
    }

    public void receiveNewScore(int score)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (PlayerPrefs.GetInt(prefPrequel + i) < score)
            {
                PlayerPrefs.SetInt(prefPrequel + i, score);
                return;
            }
        }
    }

    public void resetHighScores(int score)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            PlayerPrefs.SetInt(prefPrequel + i, 0);
        }
        refreshHighScoreTexts();
    }
}
