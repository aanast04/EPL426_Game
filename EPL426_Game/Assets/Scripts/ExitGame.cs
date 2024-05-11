using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace for UI elements

public class ExitGame : MonoBehaviour
{
    public void ExitGameOnClick()
    {
        Application.Quit(); // Call Application.Quit() to exit the game
    }
}
