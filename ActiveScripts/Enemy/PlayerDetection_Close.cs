using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection_Close : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
            Enemy.playerCloseRange = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Enemy.playerCloseRange = false;
            Enemy.playerExitSpecialStatus = true;
        }

    }
}
