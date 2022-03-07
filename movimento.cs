using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class movimento : MonoBehaviour
{
    public Rigidbody2D rb;
    public prng rng;
    private float verticalSpeed = 0, resetimer;
    private bool tempJump = false, doubleJump, isDoubleJumping, collided, ice, jumpingFromIce = false, controller, flag, flag2, jumpedLastFrame, outOfScreen = false;
    private sbyte iceGravity, directionV, Key2, objsTouched;
    private int horizontalSpeed = 0;
    private float verVelMod = 0, escape, directionH, time;
    private byte timeOut;
    public bool tempPlat, Key; // I have no clue what tempPlat is
    public byte maxTime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "jogador";
    }

    private void OnBecameInvisible()
    {
        outOfScreen = true;
        timeOut = 200;
    }
    private void OnBecameVisible()
    {
        outOfScreen = false;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        objsTouched++;
        if(objsTouched > 0 & col.gameObject.name != "chave") collided = true;
        if (collided) {
            doubleJump = false;
            isDoubleJumping = false;
            jumpingFromIce = false;
            verticalSpeed = 0;
        }
        if (col.gameObject.tag == "gelo")
        {
            ice = true;
        }
    }

    public void OnCollisionExit2D()
    {
        objsTouched--;
        if (objsTouched == 0) collided = false;
        if (collided == false)
        {
            tempJump = false;
            if (ice) jumpingFromIce = true;
            ice = false;
            iceGravity = 0;
        }
        
    }
    /*private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name != "chave") collided = true;
    }    */
    private void Update()
    {
        if (Time.frameCount % 2 == 0)
        {
            if (Input.GetKeyDown(KeyCode.R) & Input.GetKey(KeyCode.LeftControl)) { 
                Destroy(FindObjectOfType<AudioManager>().gameObject);
                FindObjectOfType<SpeedrunController>().SplitsReset();
                SceneManager.LoadScene(0);
            }
        }
        if (objsTouched < 0) objsTouched = 0;
        if (Input.GetKey(KeyCode.Escape)) escape = escape + Time.deltaTime;
        if (Input.GetKey(KeyCode.Escape) == false) escape = 0f;
        if (escape >= 1.5f) if (Application.platform == RuntimePlatform.WindowsPlayer) Application.Quit();
            else {
                Destroy(FindObjectOfType<AudioManager>().gameObject);
                SceneManager.LoadScene(0);
            }
        directionV = 0;
        directionH = 0;
        if (Input.GetKey("s")) directionV = -1;
        if (Input.GetKey(KeyCode.DownArrow)) directionV = -1;
        if (Input.GetKey(KeyCode.UpArrow)) directionV = 1;
        if (Input.GetKey(KeyCode.Space)) directionV = 1;
        if (Input.GetKey("b")) directionV = 1;
        if (Input.GetKey("v")) directionV = 1;
        if (Input.GetKey("w")) directionV = 1;
        if (Input.GetKey("d")) directionH++;
        if (Input.GetKey(KeyCode.RightArrow)) directionH++;
        if (Input.GetKey("a")) directionH--;
        if (Input.GetKey(KeyCode.LeftArrow)) directionH--;
        if (Input.GetButton("Jump")) directionV = 1;
        //if (Input.GetButtonDown("start")) controle = true;
        if (Input.GetAxis("Horizontal") != 0) directionH = Input.GetAxis("Horizontal");
        if (jumpedLastFrame & isDoubleJumping == false & collided == false & directionV != 1)
                {
                    doubleJump = true;

                }
        if (collided & directionV != 1 & ice == false) verVelMod = verticalSpeed * -1;
        else verVelMod = 0;
        //Debug.Log(direçãoH);
        if (flag == true)
        {
            flag2 = true;
            time = time + Time.deltaTime;
            if (time >= maxTime / 10) {
                time = 0;
                flag = false;
                flag2 = false;
                return;
            }
        }
        //if (Time.frameCount % 30 == 0) GC.Collect();
    }
   
    private void FixedUpdate()
    {
        if (outOfScreen) timeOut++;
        if (timeOut == 255) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (directionH > 1) directionH = 1;
        if (directionH < -1) directionH = -1;
        if (collided) if (directionV == -1) verticalSpeed = -4f;
        if (ice == false) if (collided) horizontalSpeed = 0;
        if (collided == false) horizontalSpeed = horizontalSpeed - 20;
        if (collided == false) horizontalSpeed = horizontalSpeed + 20;
        if (collided == false)
            if (verticalSpeed > 0) verticalSpeed = verticalSpeed - 25f * Time.fixedDeltaTime;
            else if (verticalSpeed <= 0) verticalSpeed = verticalSpeed - 0.7f;
        if (collided) if (verticalSpeed <= 1) if (directionV != 1) verticalSpeed = 0f;
        //if (Input.GetKey("a")) if (collided) velocidadeHorizontal = velocidadeHorizontal - 500;
        //else velocidadeHorizontal = velocidadeHorizontal - 50;
        //if (Input.GetKey("d")) if (collided) velocidadeHorizontal = velocidadeHorizontal + 500;
        //else velocidadeHorizontal = velocidadeHorizontal + 50;
        if (collided) horizontalSpeed = ((int)(horizontalSpeed + (500 * directionH)));
        else horizontalSpeed = ((int)(horizontalSpeed + (50 * directionH)));
        if (horizontalSpeed > 700) if (jumpingFromIce == false) horizontalSpeed = 700;
        if (horizontalSpeed < -700) if (jumpingFromIce == false) horizontalSpeed = -700;
        if (horizontalSpeed > 1000) if (jumpingFromIce) horizontalSpeed = 1000;
        if (horizontalSpeed < -1000) if (jumpingFromIce) horizontalSpeed = -1000;
        if (ice) iceGravity = (sbyte)(((horizontalSpeed / 30) + 10) * -1);
        if (collided) if (tempJump == false) if (directionV == 1) 
            {
                verticalSpeed = verticalSpeed + 10f;
                iceGravity = 0;
                tempJump = true;
                if (ice) jumpingFromIce = true;
                    //puloDuplo = true;
                }
        
        if (collided == false) if (directionV == 1) if (doubleJump)
                {
                    verticalSpeed = 10f;
                    doubleJump = false;
                    isDoubleJumping = true;
                }

        //Debug.Log(velocidadeHorizontal);
        rb.velocity = new Vector2(horizontalSpeed / 50, verticalSpeed + iceGravity + verVelMod);

    }
    public void jailflag(bool b)
    {
        
        if (b == false) flag = true;
        if (b) Key2 = 10;
        time = 0;
    }
    private void LateUpdate()
    {
        if (Key2 >= 1)
        {
            collided = false;
            tempJump = false;
            Key2--;
            Key = true;
        }
        if (directionV == 1) jumpedLastFrame = true;
        else jumpedLastFrame = false;
    }
    public bool CheckFlag()
    {
        return flag2;
    }
    public void Jump(byte a)
    {
        if (a == 0) return;
        if (collided) verticalSpeed = a;
    }

    


}

