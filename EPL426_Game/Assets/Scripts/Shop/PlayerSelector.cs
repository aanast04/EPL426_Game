using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] players;

    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject player in players)
            player.SetActive(false);

        players[currentCharacterIndex].SetActive(true);
    }
}
