using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpdBuffBtn : MonoBehaviour
{
    public Animator anim;

    public void Clicked()
    {
        if (!anim.GetBool("On"))
        {
            anim.SetBool("On", true);
            PlayerPrefs.SetFloat("Player_SPD", 15.0f);                  // -> 15.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Strafe", 10.0f);            // -> 10.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Approach", 15.0f);          // -> 15.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Retreat", 8.0f);            // -> 8.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Avoid", 7.0f);              // -> 7.0f
        }
        else if (anim.GetBool("On"))
        {
            anim.SetBool("On", false);
            PlayerPrefs.SetFloat("Player_SPD", 10.0f);                  // -> 15.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Strafe", 5.0f);             // -> 10.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Approach", 10.0f);          // -> 15.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Retreat", 5.0f);            // -> 8.0f
            PlayerPrefs.SetFloat("Enemy_SPD_Avoid", 3.0f);              // -> 7.0f
        }

    }
}
