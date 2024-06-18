using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButtons : MonoBehaviour
{
    public AudioManager _AudioManager;
    public AudioClip soundButton;
    void Start()
    {
        _AudioManager = GameObject.FindGameObjectWithTag("AudioManager")?.GetComponent<AudioManager>();
    }

    public void SoundButton()
    {
        _AudioManager.StartSom(soundButton);
    }
}
