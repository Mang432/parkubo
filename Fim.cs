using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour
{
    private float time;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) if (time >= 5) 
            {
                FindObjectOfType<SpeedrunController>().SplitsReset();
                SceneManager.LoadScene("Menu");
            }
        time = time + Time.deltaTime;
        if (time > 46.5f) rb.velocity = new Vector2(0, 0);
    }

}
