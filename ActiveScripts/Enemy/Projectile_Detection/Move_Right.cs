using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Right : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Projectile" && Enemy.avoidCDTimer_x <= 0f)
        {
            gameObject.GetComponentInParent<Enemy>().Avoid_x(1);
            Enemy.avoidCDTimer_x = Enemy.avoidCD;
        }
    }
}
