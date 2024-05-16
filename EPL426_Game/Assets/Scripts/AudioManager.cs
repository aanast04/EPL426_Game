using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }

        // Get the current active scene
        Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

        // Check if it's the Scene1
        if (currentScene.name == "Scene1")
        {
            PlaySound("MainTheme");
        }
        // Check if it's the Menu scene
        else if (currentScene.name == "Menu")
        {
            PlaySound("MainMenu");
        }
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
}
