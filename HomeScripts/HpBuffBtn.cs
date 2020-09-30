using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBuffBtn : MonoBehaviour
{
    public Animator anim;

    public void Clicked()
    {
        if (!anim.GetBool("On"))
        {
            anim.SetBool("On", true);
            PlayerPrefs.SetFloat("Player_HP", 130.0f);                  // -> 130.0f
            PlayerPrefs.SetFloat("Enemy_HP", 200.0f);                   // -> 200.0f
        }
        else if (anim.GetBool("On"))
        {
            anim.SetBool("On", false);
            PlayerPrefs.SetFloat("Player_HP", 100.0f);                   // -> 130.0f
            PlayerPrefs.SetFloat("Enemy_HP", 100.0f);                   // -> 200.0f
        }

    }
}
