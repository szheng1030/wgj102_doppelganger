using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGM : MonoBehaviour
{
    public static int enemyHP;
    public static int time;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = (int)(PlayerPrefs.GetFloat("Game_EnemyHP") / PlayerPrefs.GetFloat("Enemy_HP") * 100);
        time = (int)PlayerPrefs.GetFloat("Game_Time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
