using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 target;
    public float speed;

    public float damage;
    
    void Start()
    {
        speed *= PlayerPrefs.GetFloat("Player_ATK_Speed(FACTOR)");
        damage *= PlayerPrefs.GetFloat("Player_ATK_Damage(FACTOR)");
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.01f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
