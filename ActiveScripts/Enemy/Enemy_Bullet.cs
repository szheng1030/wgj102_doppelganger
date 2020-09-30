using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    Transform player;
    public static float speed = 10;
    private float actualSpeed;

    Vector2 direction;
    public float travelTime;

    public float damage;

    public int aim;

    void Start()
    {
        damage = PlayerPrefs.GetFloat("Enemy_ATK_Damage");
        player = GameObject.Find("Player").transform;

        if (aim == 0)
        {
            direction = (new Vector2(player.position.x - transform.position.x,
                player.position.y - transform.position.y)).normalized;
        }
        else if(aim == -1)
        {
            direction = (new Vector2(player.position.x - transform.position.x - 4,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == 1)
        {
            direction = (new Vector2(player.position.x - transform.position.x + 4,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == 2)
        {
            direction = (new Vector2(player.position.x - transform.position.x + 8,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == -2)
        {
            direction = (new Vector2(player.position.x - transform.position.x - 8,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == 3)
        {
            direction = (new Vector2(player.position.x - transform.position.x + 12,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == -3)
        {
            direction = (new Vector2(player.position.x - transform.position.x - 12,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == 4)
        {
            direction = (new Vector2(player.position.x - transform.position.x + 2,
                player.position.y - transform.position.y)).normalized;
        }
        else if (aim == -4)
        {
            direction = (new Vector2(player.position.x - transform.position.x - 2,
                player.position.y - transform.position.y)).normalized;
        }

        actualSpeed = speed;
        Destroy(gameObject, travelTime);
    }

    void Update()
    {
        transform.Translate(direction * actualSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponentInParent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (col.tag == "Boundary")
            Destroy(gameObject);
    }
}
