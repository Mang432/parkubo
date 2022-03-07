using System;
using UnityEngine;

public class pula : MonoBehaviour
{
    private bool jumping, start, goingDown, canJump = true;
    private float time;
    private Rigidbody2D rb;
    private GameObject player;
    public float jmpTime;
    public byte speed, jmpForce;
    public sbyte ypos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ypos = (sbyte)Math.Round(transform.position.y * 8.46f);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (start)
        {
            start = false;
            canJump = false;
            rb.velocity = new Vector2(0, speed);
            jumping = true;
            time = 0;
        }
        if (jumping & time >= jmpTime)
        {
            player.GetComponent<movimento>().Jump(jmpForce);
            jumping = false;
            goingDown = true;
            rb.velocity = new Vector2(0, speed * -1);
            time = 0;
        }
        if (goingDown & time >= jmpTime)
        {
            goingDown = false;
            rb.velocity = new Vector2(0, 0);
            canJump = true;
            transform.position = new Vector2(transform.position.x, ypos / 8.46f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "jogador" & canJump)
        {
            start = true;
            player = collision.gameObject;
        }
    }
}
