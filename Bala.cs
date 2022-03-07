using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public sbyte vel;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex != 8) GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(vel, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "jogador") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (collision.gameObject.name == "KillHitbox") Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
