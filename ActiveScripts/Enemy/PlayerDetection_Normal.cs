using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection_Normal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Enemy.playerInRange = true;
            Enemy.playerExitSpecialStatus = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
            Enemy.playerInRange = false;
    }
}
