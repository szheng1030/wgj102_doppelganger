using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Front : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Projectile" && Enemy.avoidCDTimer_y <= 0f)
        {
            gameObject.GetComponentInParent<Enemy>().Avoid_y(-1);
            Enemy.avoidCDTimer_y = Enemy.avoidCD;
        }
    }
}
