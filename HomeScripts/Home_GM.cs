using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_GM : MonoBehaviour
{
    void Start()
    {
        //////////////////////
        // DEFAULT SETTINGS //
        //////////////////////
        PlayerPrefs.SetFloat("Player_ATK_Damage(FACTOR)", 1.0f);            // -> 2.0f      DONE
        PlayerPrefs.SetFloat("Player_ATK_Rate", 0.2f);                      // -> 0.15f     DONE
        PlayerPrefs.SetFloat("Player_ATK_Speed(FACTOR)", 1.0f);             // -> 1.5f      DONE
        PlayerPrefs.SetFloat("Enemy_ATK_Damage", 2.0f);                     // -> 4.0f      DONE
        PlayerPrefs.SetFloat("Enemy_ATK_Rate(FACTOR)", 1.0f);               // -> 1.5f      DONE
        PlayerPrefs.SetFloat("Enemy_ATK_Speed(FACTOR)", 1.0f);              // -> 1.5f      DONE

        PlayerPrefs.SetFloat("Player_SPD", 10.0f);                          // -> 15.0f     DONE
        PlayerPrefs.SetFloat("Enemy_SPD_Strafe", 5.0f);                     // -> 10.0f     DONE
        PlayerPrefs.SetFloat("Enemy_SPD_Approach", 10.0f);                  // -> 15.0f     DONE
        PlayerPrefs.SetFloat("Enemy_SPD_Retreat", 5.0f);                    // -> 8.0f      DONE
        PlayerPrefs.SetFloat("Enemy_SPD_Avoid", 3.0f);                      // -> 7.0f      DONE

        PlayerPrefs.SetFloat("Player_HP", 100.0f);                           // -> 130.0f    DONE
        PlayerPrefs.SetFloat("Enemy_HP", 100.0f);                           // -> 200.0f    DONE
    }
}
