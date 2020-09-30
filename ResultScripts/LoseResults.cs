using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseResults : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = "Time Spent: " + LoseGM.time + "s\n" +
            "Enemy HP: " + LoseGM.enemyHP + "%";
    }
}
