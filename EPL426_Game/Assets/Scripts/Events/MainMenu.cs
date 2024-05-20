using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
        
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {

        coinsText.text = "Coin Balance: " + PlayerPrefs.GetInt("TotalCoins", 0).ToString();
    }

    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
