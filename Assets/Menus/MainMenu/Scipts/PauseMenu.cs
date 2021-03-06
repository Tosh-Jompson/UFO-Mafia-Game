﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public string mainMenuScene;
    public GameObject pauseMenu;
    public GameObject Buttons;
    public GameObject APMenu;
    public GameObject tutorialMenu;
    public GameObject Playercounter;

    public bool isPaused;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                isPaused = true;
                tutorialMenu.SetActive(true);
                

                Time.timeScale = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();

            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Buttons.SetActive(false);
                APMenu.SetActive(false);
                Playercounter.SetActive(false);

                Time.timeScale = 0f;
            }
        }
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        Buttons.SetActive(true);
        APMenu.SetActive(true);
        Playercounter.SetActive(true);

        Time.timeScale = 1f;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ReturnToLevelselect()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 1f;

    }
   
    
}