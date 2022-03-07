using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public class prng : MonoBehaviour
{
    // Deprecated in favor of DadoNovo


    private uint ticks;
    private uint porcento;
    private byte counter;
    private byte modfier;

    // Start is called before the first frame update
    void Awake()
    {
        porcento = inicPor();
    }

         

    public byte Porcentagem()
    {
        /*counter++;
        porcento = ((uint)(((porcento + entropia) * 89) + modfier) % 101);
        entropia = 0;
        if (porcento == 0) porcento = 1;
        //Debug.Log(porcento);
        if (counter == 47)
        {
            counter = 0;
            modfier++;
            if (modfier == 98) modfier = 0;
        }
        return (byte)porcento;*/
        return (byte)DadoNovo.RandomNext(1, 100);
    }
    private byte inicPor()
    {
        uint tmp = (uint)Time.frameCount % 512;
        uint tmp2 = ((uint)Time.frameCount) >> 4;
        modfier = (byte)(Time.frameCount % 98);
        return (byte)((tmp ^ tmp2) % 101);
    }
}

