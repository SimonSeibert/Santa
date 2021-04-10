using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    public TextMeshProUGUI scoreText;
    //public string scoreMessage = "Score: ";
    public float scoreTextSuccessScaling = 1.5f;
    public float scoreTextSuccessScalingTime = 1f;
    [Header("Fails")]
    public TextMeshProUGUI failsLeftText;
    public float failsLeftTextFailureRotation = 20f;
    public float failsLeftTextFailureScalingTime = 1f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void score(bool success)
    {
        //if (DataManager.Instance.getIsGameRunning())
        //{


        if (success)
        {
            Data.Instance.addScore(1);
            scoreText.SetText("" + Data.Instance.getCurrentScore());

            //Happy Scaling
            transform.localScale = Vector3.one;
            LeanTween.scale(scoreText.gameObject, Vector3.one * scoreTextSuccessScaling, scoreTextSuccessScalingTime / 2)
                .setFrom(Vector3.one)
                .setEaseInOutSine();
            LeanTween.scale(scoreText.gameObject, Vector3.one, scoreTextSuccessScalingTime / 2)
                .setFrom(Vector3.one * scoreTextSuccessScaling)
                .setDelay(scoreTextSuccessScalingTime / 2)
                .setEaseInOutSine();
        }
        else
        {
            if (failsLeftText != null)
            {

                Data.Instance.failure(1);
                failsLeftText.SetText("Misses: " + Data.Instance.getCurrentFailures() + "/" + Data.Instance.getAllowedFailures());

                //Sad Wiggle
                transform.localRotation = Quaternion.identity;
                LeanTween.rotate(failsLeftText.gameObject, new Vector3(0f, 0f, failsLeftTextFailureRotation), failsLeftTextFailureScalingTime / 4)
                    .setFrom(new Vector3(0f, 0f, 0f))
                    .setEaseInOutSine();
                LeanTween.rotate(failsLeftText.gameObject, new Vector3(0f, 0f, -failsLeftTextFailureRotation), failsLeftTextFailureScalingTime / 2)
                    .setDelay(failsLeftTextFailureScalingTime / 4)
                    .setEaseInOutSine();
                LeanTween.rotate(failsLeftText.gameObject, new Vector3(0f, 0f, 0f), failsLeftTextFailureScalingTime / 4)
                    .setDelay(failsLeftTextFailureScalingTime / 2 + failsLeftTextFailureScalingTime / 4)
                    .setEaseInOutSine();

                if (Data.Instance.getCurrentFailures() <= 0)
                {
                    GameObject.FindGameObjectWithTag("Menu_Manager").GetComponent<MenuManager>().activateGameOverUI();
                    GameObject.FindGameObjectWithTag("Menu_Manager").GetComponent<HighScores>().receiveNewScore(Data.Instance.getCurrentScore());
                }
            }
        }
        //}
    }
}
