using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject howToPlayUI;
    public GameObject[] inGameObjects;


    void Start()
    {
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
    }

    public void activateInGameUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(false);
    }

    public void activateGameOverUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);
        howToPlayUI.SetActive(false);
    }

    public void activateHowToPlayUI()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
        howToPlayUI.SetActive(true);
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
}
