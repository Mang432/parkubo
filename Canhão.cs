using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canhão : MonoBehaviour
{
    public Rigidbody2D bullet;
    public prng rng;
    public Transform barrel;
    public Yscroll ys;
    private int tickwaiter;
    float timer;

    void Start()
    {
        tickwaiter = rng.Porcentagem() * 2;
        timer = DadoNovo.FRandom() * 4f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            /*if (rng.Porcentagem() == 21)
            {
                Instantiate(bala, barril.position, barril.rotation);
                tickwaiter = 20;
                return;
            }*/
            //tickwaiter = ((rng.Porcentagem()) * 3);
            //tickwaiter = (rng.Porcentagem() * ((rng.Porcentagem() % 3) + 1));
            timer = (DadoNovo.FRandom() + DadoNovo.FRandom()) * 3f;
            if (SceneManager.GetActiveScene().buildIndex == 8) ys.ChangePos();
            Instantiate(bullet, barrel.position, barrel.rotation);
        }


        //if (rng.Porcentagem() == 34) Instantiate(bala, barril.position, barril.rotation);

    }
    private void FixedUpdate()
    {
        tickwaiter--;
        //if (rng.Porcentagem() == 34) Instantiate(bala, barril.position, barril.rotation);
    }

    private byte RandWait()
    {
        return (byte)((rng.Porcentagem() * (rng.Porcentagem() % 3)) + 75);
    }
}
