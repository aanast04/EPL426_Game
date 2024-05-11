using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[Header("------- Audio Source --------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    //[Header("------- Audio Clip --------")]
    public AudioClip MainMenu;
    public AudioClip Gameplay;
    public AudioClip jump;
    public AudioClip lose;
    public AudioClip buttons;

    private void Start()
    {
        musicSource.clip = MainMenu;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
