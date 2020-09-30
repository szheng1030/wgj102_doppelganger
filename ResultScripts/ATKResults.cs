using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATKResults : MonoBehaviour
{
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.GetFloat("Player_ATK_Damage(FACTOR)") == 1.0f)
            rend.color = new Color(0.85f, 0.85f, 0.85f, 1.0f);   
        else if (PlayerPrefs.GetFloat("Player_ATK_Damage(FACTOR)") == 2.0f)
            rend.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
