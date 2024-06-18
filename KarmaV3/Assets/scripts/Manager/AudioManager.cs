using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource FonteSFX;
    void Start()
    {
        FonteSFX = GetComponent<AudioSource>();
    }

    public void StartSom(AudioClip Som)
    {
        FonteSFX.PlayOneShot(Som);
    }
}
