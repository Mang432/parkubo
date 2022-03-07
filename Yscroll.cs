using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yscroll : MonoBehaviour
{
    public prng rng;
    private float pos;
    public void ChangePos()
    {
        pos = (((rng.Porcentagem() / 2) % 28) - 14);
        transform.position = new Vector2(transform.position.x, pos);
    }
}
