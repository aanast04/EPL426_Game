using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    //AudioManager audioManager;

    //private void Awake()
    //{
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //}

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        Time.timeScale = 1.0f;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(gameOver)
        {
            
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            //audioManager.PlaySFX(audioManager.lose);
        }

        coinsText.text = "Coins: " + numberOfCoins;


    }
}
