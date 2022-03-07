using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musica : MonoBehaviour
{
    public AudioClip clip;
    public byte clipstart;
    private AudioManager AM;
    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        if (AM.PreviousScene() != SceneManager.GetActiveScene().buildIndex)
        {
            AM.ChangeMusic(clip);
            AM.SetScene();
        }
    }
}