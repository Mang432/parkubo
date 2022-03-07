using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Novojogo : MonoBehaviour
{
    private bool isGood = false; // ????????????
    public void novoJogo()
    {
        FindObjectOfType<SpeedrunController>().LoadStuff();
        SceneManager.LoadScene("tutorial");
    }
}
