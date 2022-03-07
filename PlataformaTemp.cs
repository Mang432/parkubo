using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTemp : MonoBehaviour
{
    private movimento mov;
    private Collider2D myCol;
    private SpriteRenderer Mesh;
    // Start is called before the first frame update
    void Start()
    {
        mov = FindObjectOfType<movimento>();
        myCol = GetComponent<Collider2D>();
        Mesh = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov == null) mov = FindObjectOfType<movimento>();
        if (mov.CheckFlag() == true) {
            myCol.enabled = true;
            Mesh.color = new Color(255, 255, 255, 1);
        }
        else {
            myCol.enabled = false;
            Mesh.color = new Color(255, 255, 255, 0.3f);
        }

    }
}
