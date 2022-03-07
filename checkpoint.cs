using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private AudioManager AM;
    public bool checkspawn;
    public Transform spawn;
    public GameObject player;
    private bool fadeOut;
    private float color = 1;

    // Update is called once per frame
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        if (AM.Checkpoint() == checkspawn) Instantiate(player, spawn.position, spawn.rotation);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jogador")
        {
            if (AM.Checkpoint() != checkspawn) fadeOut = true;
            AM.SetCheckpoint(checkspawn);
        }
    }
    private void Update()
    {
        if (fadeOut)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, color);
            color = color - Time.deltaTime;
        }
    }
}
