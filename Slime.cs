using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public prng rng;
    public Rigidbody2D rb;
    private bool collided = false;
    private float versticalSpeed;
    private float horizontalSpeed;
    private byte timeWithoutJumping = 0;
    private int oddsAndEvens;
    private bool even = false;
    int tickwaiter = 0;
    
    void FixedUpdate()
    {
        if (tickwaiter == 0)
        {

            tickwaiter = (DadoNovo.RandomNext(1,100));
            if (collided) versticalSpeed = ((tickwaiter) + 150);
            if (tickwaiter % 2 == 0) even = true;
            else even = false;
            horizontalSpeed = 0;
        }
        if (tickwaiter < 0) tickwaiter = tickwaiter * -1;
        if (even) if (collided == false) horizontalSpeed = -100;
        if (even == false) if (collided == false) horizontalSpeed = 100;
        // Coisas de movimento
        if (collided == false) versticalSpeed = versticalSpeed - 10f;

        if (collided) if (versticalSpeed <= 1) versticalSpeed = -0.1f;
        tickwaiter--;

        // O código a seguir verifica a quanto tempo o slime está com a variável collided no false,
        // há um glitch onde o slime colide com outro slime antes de tocar o chão, mas continua
        // colidindo com ele quando ele chega no chão. Isso acaba deixando a variável travada no
        // false mesmo quando o slime está tocando o chão. É uma gambiarra, mas funciona

        if (collided == false) timeWithoutJumping++;
        if (timeWithoutJumping >= 255) collided = true;
        if (collided) timeWithoutJumping = 0;
        rb.velocity = new Vector2(horizontalSpeed * Time.fixedDeltaTime, versticalSpeed * Time.fixedDeltaTime);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "slime") collided = true;
        horizontalSpeed = 0;
        versticalSpeed = 0;
        if (col.gameObject.name == "KillHitbox") Destroy(gameObject);
    }

    public void OnCollisionExit2D()
    {
        collided = false;
        
    }

}
