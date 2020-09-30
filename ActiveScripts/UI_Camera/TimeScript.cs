using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text time;
    private int current;
    int endTime;

    void Update()
    {
        if (GameMaster.gameEnd)
        {
            PlayerPrefs.SetFloat("Game_Time", endTime);
            time.text = endTime.ToString();
        }
        else
        {
            current = (int)(Time.timeSinceLevelLoad - 1.2f);
            if (current <= 0)
                time.text = "0";
            else if (current > 0)
                time.text = current.ToString();
            endTime = current;
        }
    }
}
