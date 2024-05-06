using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{

    public void ReplayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

