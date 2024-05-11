using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    //AudioManager audioManager;

    //private void Awake()
    //{
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //}

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1.0f;
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


    }
}
