using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    bool isPaused = false;
    public GameObject activeGameObject;

    public void ReplayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // This will pause the game
        isPaused = true;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1f; // This will resume the game
        isPaused = false;
    }

}

