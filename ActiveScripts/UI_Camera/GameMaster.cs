using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    GameObject player;
    GameObject enemy;
    GameObject enemyDetect1;
    GameObject enemyDetect2;

    public Animator anim_L;
    public Animator anim_R;

    public static bool gameEnd = false;

    void Start()
    {
        gameEnd = false;
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        enemyDetect1 = GameObject.Find("Close_Range");
        enemyDetect2 = GameObject.Find("Normal_Range");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            gameEnd = true;

            enemy.GetComponent<Enemy_Gun>().enabled = false;
            enemyDetect1.GetComponent<PlayerDetection_Close>().enabled = false;
            enemyDetect2.GetComponent<PlayerDetection_Normal>().enabled = false;
            Enemy.current = Enemy.State.normalRange;

            StartCoroutine(LoseDelay());
        }
        else if(enemy == null)
        {
            gameEnd = true;

            StartCoroutine(WinDelay());
        }
    }

    IEnumerator WinDelay()
    {
        anim_L.SetBool("SceneChange", true);
        anim_R.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("WinResult");
    }

    IEnumerator LoseDelay()
    {
        anim_L.SetBool("SceneChange", true);
        anim_R.SetBool("SceneChange", true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LoseResult");
    }
}
