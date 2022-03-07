using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    public movimento mov;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "jogador")
        {
            mov.jailflag(true);
            Destroy(gameObject);
        }
    }
}
