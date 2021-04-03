using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;
    private List<int> scoresList;

    void OnEnable()
    {
        refreshHighScoreTexts();
    }

    private void refreshHighScoreTexts()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + ": " + PlayerPrefs.GetInt("HighScore" + i);
        }
    }

    public void receiveNewScore(int score)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (PlayerPrefs.GetInt("HighScore" + i) < score)
            {
                PlayerPrefs.SetInt("HighScore" + i, score);
                return;
            }
        }
    }

    public void resetHighScores(int score)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, 0);
        }
        refreshHighScoreTexts();
    }
}
