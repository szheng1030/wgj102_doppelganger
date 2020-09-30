using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPDResults : MonoBehaviour
{
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetFloat("Player_SPD") == 10.0f)
            rend.color = new Color(0.85f, 0.85f, 0.85f, 1.0f);
        else if (PlayerPrefs.GetFloat("Player_SPD") == 15.0f)
            rend.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
