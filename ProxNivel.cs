using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ProxNivel : MonoBehaviour
{
    public SaveLoad sl;
    private AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "jogador")
        {
            FindObjectOfType<SpeedrunController>().Split();
            AM.TimerStop();
            AM.SetCheckpoint(false);
            GC.Collect();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
