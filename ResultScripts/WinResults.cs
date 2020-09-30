using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinResults : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "Time Spent: " + WinGM.time + "s\n" +
            "Player HP: " + WinGM.playerHP + "%";
    }

}
