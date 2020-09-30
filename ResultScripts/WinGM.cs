using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGM : MonoBehaviour
{
    public static int playerHP;
    public static int time;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = (int)(PlayerPrefs.GetFloat("Game_PlayerHP") / PlayerPrefs.GetFloat("Player_HP") * 100);
        time = (int)PlayerPrefs.GetFloat("Game_Time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
