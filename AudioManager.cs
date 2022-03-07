using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public AudioSource BGM;
	private static AudioManager instance;
	private byte SceneValue;
	private bool checkpointer = false;
	public float[] time = new float[8]; // old array for timing, unused
	private float timer;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else Destroy(gameObject);
	}
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0 && SceneManager.GetActiveScene().buildIndex < 9)
        {
			timer += Time.deltaTime;
        }
    }
    public void ChangeMusic(AudioClip music)
	{
		BGM.Stop();
		BGM.clip = music;
		BGM.Play();
	}
	public byte PreviousScene()
	{
		return SceneValue;
	}
	public void SetScene()
	{
	    SceneValue = (byte)SceneManager.GetActiveScene().buildIndex;
	}
	public void SetCheckpoint(bool val)
    {
		checkpointer = val;
    }
	public bool Checkpoint()
    {
		return checkpointer;
    }
	public void TimerStop()
    {
		time[SceneManager.GetActiveScene().buildIndex - 1] = timer;
		//Debug.Log(time[SceneManager.GetActiveScene().buildIndex - 1] + " " + timer);
		timer = 0;
    }
}