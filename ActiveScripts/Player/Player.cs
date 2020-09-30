using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Camera mainCamera;

    public float speed;
    float horizontal, vertical;
    Vector2 movementVelocity;

    public static float hp;
    public GameObject playerHit;
    public GameObject player_destroy;

    void Start()
    {
        speed = PlayerPrefs.GetFloat("Player_SPD");
        hp = PlayerPrefs.GetFloat("Player_HP");
        rb = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            movementVelocity = movementInput.normalized * speed / 2;
        else
            movementVelocity = movementInput.normalized * speed;

        if (hp <= 0)
        {
            Instantiate(player_destroy, gameObject.transform.position, Quaternion.identity);
            PlayerPrefs.SetFloat("Game_EnemyHP", Enemy.hp);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        Instantiate(playerHit, gameObject.transform.position, Quaternion.identity);
        hp -= damage;
    }
}
