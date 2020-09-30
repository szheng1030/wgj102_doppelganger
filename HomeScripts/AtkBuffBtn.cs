using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBuffBtn : MonoBehaviour
{
    public Animator anim;

    public void Clicked()
    {
        if (!anim.GetBool("On"))
        {
            anim.SetBool("On", true);
            PlayerPrefs.SetFloat("Player_ATK_Damage(FACTOR)", 2.0f);    // -> 2.0f
            PlayerPrefs.SetFloat("Player_ATK_Rate", 0.15f);             // -> 0.15f
            PlayerPrefs.SetFloat("Player_ATK_Speed(FACTOR)", 1.5f);     // -> 1.5f
            PlayerPrefs.SetFloat("Enemy_ATK_Damage", 4.0f);             // -> 4.0f
            PlayerPrefs.SetFloat("Enemy_ATK_Rate(FACTOR)", 1.5f);       // -> 1.5f
            PlayerPrefs.SetFloat("Enemy_ATK_Speed(FACTOR)", 1.5f);      // -> 1.5f
        }
        else if(anim.GetBool("On"))
        {
            anim.SetBool("On", false);
            PlayerPrefs.SetFloat("Player_ATK_Damage(FACTOR)", 1.0f);    // -> 2.0f
            PlayerPrefs.SetFloat("Player_ATK_Rate", 0.2f);              // -> 0.15f
            PlayerPrefs.SetFloat("Player_ATK_Speed(FACTOR)", 1.0f);     // -> 1.5f
            PlayerPrefs.SetFloat("Enemy_ATK_Damage", 2.0f);             // -> 4.0f
            PlayerPrefs.SetFloat("Enemy_ATK_Rate(FACTOR)", 1.0f);       // -> 1.5f
            PlayerPrefs.SetFloat("Enemy_ATK_Speed(FACTOR)", 1.0f);      // -> 1.5f
        }

    }
}
