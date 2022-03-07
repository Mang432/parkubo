using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpscounter : MonoBehaviour //unused
{
    private Text fps;
    private string fpstext;
    
    void Start()
    {
        fps = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        fpstext = "fps " + 1 / Time.deltaTime;
        fps.text = fpstext;
    }
}
