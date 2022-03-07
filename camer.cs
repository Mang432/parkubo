using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camer : MonoBehaviour
{
    CinemachineVirtualCamera cin;
    GameObject player;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player"); // idk what this code does, but i think it has to do with the checkpoint system
        cin = GetComponent<CinemachineVirtualCamera>();
        cin.Follow = player.transform;
    }
}
