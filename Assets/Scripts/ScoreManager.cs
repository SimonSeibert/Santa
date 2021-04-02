using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public string scoreMessage = "Score: ";
    public float scoreTextSuccessScaling = 1.5f;
    public float scoreTextSuccessScalingTime = 1f;
    public float scoreTextFailureRotation = 20f;
    public float scoreTextFailureScalingTime = 1f;

    void Start()
    {

    }

    void Update()
    {

    }

    public void score(bool success)
    {
        if (success)
        {
            DataManager.Instance.addScore(1);

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
            //Sad Wiggle
            transform.localRotation = Quaternion.identity;
            LeanTween.rotate(scoreText.gameObject, new Vector3(0f, 0f, scoreTextFailureRotation), scoreTextFailureScalingTime / 4)
                .setFrom(new Vector3(0f, 0f, 0f))
                .setEaseInOutSine();
            LeanTween.rotate(scoreText.gameObject, new Vector3(0f, 0f, -scoreTextFailureRotation), scoreTextFailureScalingTime / 2)
                .setDelay(scoreTextFailureScalingTime / 4)
                .setEaseInOutSine();
            LeanTween.rotate(scoreText.gameObject, new Vector3(0f, 0f, 0f), scoreTextFailureScalingTime / 4)
                .setDelay(scoreTextFailureScalingTime / 2 + scoreTextFailureScalingTime / 4)
                .setEaseInOutSine();

            if (DataManager.Instance.getCurrentScore() > 0)
            {
                DataManager.Instance.addScore(-1);

            }
        }
        scoreText.SetText(scoreMessage + DataManager.Instance.getCurrentScore());
    }
}
