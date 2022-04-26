using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause: MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // public GameObject volumeMenuUI;


    private void Start()
    {
        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /*  public void Volume()
      {
          pauseMenuUI.SetActive(false);
          volumeMenuUI.SetActive(true);
          Time.timeScale = 0f;
          GameIsPaused = true;
      }
  */
    void pause()
    {
        pauseMenuUI.SetActive(true);
        //volumeMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartLevel()
    {
        PlayerPrefs.Save();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Resume();
    }

    public void MainMenu()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        Application.Quit();
    }
}