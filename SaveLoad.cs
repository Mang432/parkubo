using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
    //Unused routine to save and load game data

    public void SaveGame()
    {
        PlayerPrefs.SetInt("nivel", SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Salvo" + PlayerPrefs.GetInt("nivel"));
    }
    public void LoadGame()
    {

        SceneManager.LoadScene(PlayerPrefs.GetInt("nivel"));
        Debug.Log("Carregado" + PlayerPrefs.GetInt("nivel"));


    }
}
