using UnityEngine;
using UnityEngine.UI;

public class ShowTimes : MonoBehaviour // Old time formatting code
{
    AudioManager AM;
    Text text;
    string[] Times = new string[8];
    float total;
    string[] TotalTimes = new string[3];
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        text = GetComponent<Text>();
        for (byte b = 0;b < 8; b++)
        {
            float tempo = AM.time[b] / 100f;
            total += tempo;
            string min = Mathf.Floor(tempo / 60f).ToString("0");
            string seg = Mathf.Floor(tempo % 60).ToString("00");
            string cen = ((tempo - Mathf.Floor(tempo)) * 100).ToString("00");
            Times[b] = min + ":" + seg + "," + cen;
            if (tempo >= 600) Times[b] = "+9:59,99";
        }
        TotalTimes[0] = Mathf.Floor(total / 60f).ToString("0");
        TotalTimes[1] = Mathf.Floor(total % 60).ToString("00");
        TotalTimes[2] = ((total - Mathf.Floor(total)) * 100).ToString("00");
        text.text = "Level 1: " + Times[0] + "\n" + "Level 2: " + Times[1] + "\n" + "Level 3: " + Times[2] + "\n" + "Level 4: " + Times[3] + 
        "\n" + "Level 5: " + Times[4] + "\n" + "Level 6: " + Times[5] + "\n" + "Level 7: " + Times[6] + "\n" + "Level 8: " + Times[7] + 
        "\nTotal: " + TotalTimes[0] + ":" + TotalTimes[1] + "," + TotalTimes[2];
    }

}
