using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpeedrunController : MonoBehaviour 
{
	static SpeedrunController instance;
	[SerializeField] bool noSplits;
	[SerializeField] sbyte currentLevel = -1;
	[SerializeField] Canvas _canvas;
	public float totalTime, PB, SoB; // all seconds
	public float[] levels = new float[8]; // seconds
	public int[] PBtimes = new int[8]; // milliseconds
	public int[] goldTimes = new int[8]; //milliseconds
	public string[] splitNames = new string[8];
	[SerializeField] TextMeshProUGUI[] splits = new TextMeshProUGUI[8];
	[SerializeField] TextMeshProUGUI sobGui;
	[SerializeField] Text timer;

	private void Start() {
		if (instance == null) instance = this;
		else Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		LoadStuff();
		_canvas.enabled = false;
	}



	// Update is called once per frame
	void Update()
	{
		if (currentLevel > -1 & currentLevel < 8)
		{
			totalTime += Time.deltaTime;
			levels[currentLevel] += Time.deltaTime;
			byte hundreths = (byte)((totalTime * 100f) % 100);
			byte seconds = (byte)(totalTime % 60);
			byte minutes = (byte)(totalTime / 60f);
			timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, hundreths);
		}
	}

	public void SplitsReset() {
		instance = null;
		Destroy(gameObject);
	}

	public void Split() {
		totalTime = 0;
		foreach (float f in levels)
        {
			totalTime += f;
        }
		int cebolinha = 0; // PB
		for (int i = 0; i <= currentLevel; i++)
        {
			cebolinha += PBtimes[i];
        }
		float timeDif = (totalTime - (cebolinha / 1000f));
		string monica; // Comp string
		if (timeDif < 0) monica = "green";
		else monica = "red";
		if ((levels[currentLevel] * 1000) < goldTimes[currentLevel] || noSplits)
        {
            monica = "yellow";
			goldTimes[currentLevel] = (int)(levels[currentLevel] * 1000);
			if (!noSplits) SaveStuff();
		}
		if (timeDif < 0) timeDif *= -1;
		byte tdTenths = (byte)((timeDif % 1) * 10);
		byte tdSeconds = (byte)(timeDif % 60);
		byte tdMinutes = (byte)(timeDif / 60f);
		byte totSeconds = (byte)(totalTime % 60);
		byte totMinutes = (byte)(totalTime / 60f);
		string difText = string.Format("{1}:{2:00}.{3}</color>", monica, tdMinutes, tdSeconds, tdTenths); // holy crap formatting sucks
		splits[currentLevel].text = noSplits
            ? string.Format("{0}     - {1}:{2:00}", splitNames[currentLevel].PadRight(8), totMinutes.ToString().PadLeft(2), totSeconds)
            : string.Format("{0}<color={1}>{2} {3}:{4:00}", splitNames[currentLevel].PadRight(8), monica, difText.PadRight(14), totMinutes.ToString().PadLeft(2), totSeconds);
		// Check if it is pb
		if (currentLevel == 7)
        {
			if (totalTime < PB || noSplits) //PB
            {
				for (byte b = 0; b < PBtimes.Length; b++)
                {
					PBtimes[b] = (int)(levels[b] * 1000f);
                }
				PB = totalTime;
            }
			SaveStuff(); //Save anyway
        }
    }
	public void LoadStuff() {
		if (!PlayerPrefs.HasKey("level1"))
        {
			noSplits = true;
			for (int i = 1; i <= 8; i++)
            {
				if (!PlayerPrefs.HasKey("name" + i)) PlayerPrefs.SetString("name" + i, splitNames[i - 1]);
            }
			PlayerPrefs.Save();
			Magali();
			return;
        }
		for (int i = 1; i <= 8; i++)
        {
			PBtimes[i - 1] = PlayerPrefs.GetInt("level" + i.ToString(), 0);
			goldTimes[i - 1] = PlayerPrefs.GetInt("sob" + i.ToString(), int.MaxValue);
        }
		foreach (int i in PBtimes)
        {
			PB += i / 1000f;
        }
		foreach (int i in goldTimes)
        {
			SoB += i / 1000f;
        }
		Magali();
		if (PB == 0) noSplits = true;
	}

	void Magali() {
		for (int i = 1; i <= 8; i++)
		{
			splitNames[i - 1] = PlayerPrefs.GetString("name" + i, "error");
			Debug.Log("Loaded " + PlayerPrefs.GetString("name" + i) + " as " + splitNames[i - 1]);
			if (splitNames[i - 1].Length > 8) splitNames[i - 1] = splitNames[i - 1].Substring(0, 8);
		}
		totalTime = 0f;
		for (int i = 0; i < 8; i++)
		{
			totalTime += PBtimes[i] / 1000f;
			splits[i].text = string.Format("{0}     - {1}:{2:00}", splitNames[i].PadRight(8), Mathf.Floor(totalTime / 60f).ToString().PadLeft(2), Mathf.Floor(totalTime % 60));
		}
		totalTime = 0f;
	}

	void SaveStuff() {
		for (int i = 1; i <= 8; i++)
        {
			PlayerPrefs.SetInt("level" + i, PBtimes[i - 1]);
			PlayerPrefs.SetInt("sob" + i, goldTimes[i - 1]);
        }
		PlayerPrefs.Save();
    }

	private void OnLevelWasLoaded(int level) {
		if (level > 0) _canvas.enabled = true;
		else _canvas.enabled = false;
		currentLevel = (sbyte)(level - 1);

    }
}