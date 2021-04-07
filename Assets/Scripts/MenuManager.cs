using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MenuManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject howToPlayUI;
    public GameObject highScoreUI;
    public GameObject[] inGameObjects;

    private AudioSource clickAudio;

    void Start()
    {
        clickAudio = GetComponent<AudioSource>();

        activateMenuUI();
        foreach (GameObject go in inGameObjects)
        {
            go.SetActive(false);
        }
    }

    void Update()
    {

    }

    public void activateMenuUI()
    {
        menuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(false);
        highScoreUI.SetActive(false);
        //DataManager.Instance.setIsGameRunning(false);
    }

    void activateInGameUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(false);
        highScoreUI.SetActive(false);
        //DataManager.Instance.setIsGameRunning(true);
    }

    public void activateGameOverUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
        howToPlayUI.SetActive(false);
        highScoreUI.SetActive(false);
        //DataManager.Instance.setIsGameRunning(false);
    }

    public void activateHowToPlayUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(true);
        highScoreUI.SetActive(false);
        //DataManager.Instance.setIsGameRunning(false);
    }

    public void activateHighScoreUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(false);
        highScoreUI.SetActive(true);
        //DataManager.Instance.setIsGameRunning(false);
    }

    public void startGame()
    {
        activateInGameUI();
        foreach (GameObject go in inGameObjects)
        {
            go.SetActive(true);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void playClickSound()
    {
        clickAudio.PlayOneShot(clickAudio.clip);
    }
}
