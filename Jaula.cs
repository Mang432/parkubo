using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jaula : MonoBehaviour
{
    private byte counter;
    public movimento mov;
    // Start is called before the first frame update
    void Start()
    {
        mov = FindObjectOfType<movimento>();
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter == 255)
        {
            if (mov.Key)
            {
                Destroy(gameObject);
                return;
            }
            counter = 0;
        }
    }
}
