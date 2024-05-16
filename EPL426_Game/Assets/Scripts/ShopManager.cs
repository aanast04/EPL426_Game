using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characters;

    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characters)
            character.SetActive(false);

        characters[currentCharacterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext()
    {
        characters[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characters.length)
            currentCharacterIndex = 0;


        characters[currentCharacterIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);

    }
}
