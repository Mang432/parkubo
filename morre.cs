using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class morre : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.name == "jogador") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "jogador") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
