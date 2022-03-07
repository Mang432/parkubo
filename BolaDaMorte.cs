using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDaMorte : MonoBehaviour
{
    private bool side;
    private float Vel, tmpVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vel = Vel - 220 * Time.deltaTime;
        if (side) tmpVel = Vel;
        else tmpVel = Vel * -1;
        transform.Rotate(0, 0, tmpVel * Time.deltaTime);
        if (Vel < 0)
        {
            if (side) side = false;
            else side = true;
            Vel = 300;
        }
    }
}
