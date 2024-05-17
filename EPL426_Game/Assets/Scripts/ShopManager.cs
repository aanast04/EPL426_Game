using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characters;

    public CharactersBluePrint[] characts;
    public Button buyButton;

    void Start()
    {

        foreach(CharactersBluePrint charact in characts)
        {
            if (charact.price == 0)
                charact.isUnlocked = true;
            else
                charact.isUnlocked = PlayerPrefs.GetInt(charact.name, 0)==0 ? false: true;
        }

        currentCharacterIndex = PlayerPrefs.GetInt("SelectedChar", 0);
        foreach (GameObject character in characters)
            character.SetActive(false);

        characters[currentCharacterIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        characters[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characters.Length)
            currentCharacterIndex = 0;


        characters[currentCharacterIndex].SetActive(true);
        CharactersBluePrint c = characts[currentCharacterIndex];
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);

    }

    public void ChangePrevious()
    {
        characters[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
            currentCharacterIndex = characters.Length -1;


        characters[currentCharacterIndex].SetActive(true);
        CharactersBluePrint c = characts[currentCharacterIndex];
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);

    }

    private void UpdateUI()
    {
        CharactersBluePrint c = characts[currentCharacterIndex];
        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy-" + c.price;
            if(c.price <= PlayerPrefs.GetInt("TotalCoins", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }

    public void UnlockCharacter()
    {
        CharactersBluePrint c = characts[currentCharacterIndex];

        PlayerPrefs.SetInt(c.name, 0);
        PlayerPrefs.SetInt("SelectedChar", currentCharacterIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins", 0) - c.price);
    }
}
