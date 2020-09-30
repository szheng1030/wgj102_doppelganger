using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPResults : MonoBehaviour
{
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Debug.Log(PlayerPrefs.GetFloat("Player_HP"));
        if (PlayerPrefs.GetFloat("Player_HP") == 100.0f)
            rend.color = new Color(0.85f, 0.85f, 0.85f, 1.0f);
        else if (PlayerPrefs.GetFloat("Player_HP") == 130.0f)
            rend.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
