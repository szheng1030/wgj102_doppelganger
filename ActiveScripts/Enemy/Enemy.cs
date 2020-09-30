using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        normalRange,
        farRange,
        farMove,
        closeRange,
        closeMove,
    }
    public static State current = State.normalRange;
    public static bool playerInRange;
    public static bool playerCloseRange;

    public float stateCD;
    float stateCDTimer;
    public static bool playerExitSpecialStatus;

    public float closeCD;
    float closeCDTimer;

    public float farCD;
    float farCDTimer;

    bool stateCanChange;
    public float strafeCD;
    float strafeCDTimer;
    float strafeDirection;
    public float strafeSpd;

    public float approachSpd;
    public float retreatSpd;

    public Transform playerPos;
    private Rigidbody2D rb;

    float xVelocity;
    float yVelocity;

    Vector2 moveVelocity;

    public static float avoidCD;
    public static float avoidCDTimer_x;
    public static float avoidCDTimer_y;
    public float avoidSpd;

    public static float hp_total = 100;
    public static float hp;
    public GameObject enemy_hit;
    public GameObject enemy_destroy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInRange = true;
        playerCloseRange = false;

        stateCanChange = true;
        stateCDTimer = 1.2f;
        closeCDTimer = closeCD;

        playerExitSpecialStatus = false;

        strafeCDTimer = 1.2f;

        avoidCD = 0.5f;
        avoidCDTimer_x = 1.2f;
        avoidCDTimer_y = 1.2f;

        hp_total = PlayerPrefs.GetFloat("Enemy_HP");
        hp = hp_total;

        strafeSpd = PlayerPrefs.GetFloat("Enemy_SPD_Strafe");
        approachSpd = PlayerPrefs.GetFloat("Enemy_SPD_Approach");
        retreatSpd = PlayerPrefs.GetFloat("Enemy_SPD_Retreat");
        avoidSpd = PlayerPrefs.GetFloat("Enemy_SPD_Avoid");
    }

    void Update()
    {
        if (hp <= 0f)
        {
            Instantiate(enemy_destroy, gameObject.transform.position, Quaternion.identity);
            PlayerPrefs.SetFloat("Game_PlayerHP", Player.hp);
            Destroy(gameObject);
        }

        if (stateCDTimer <= 0f)
            stateCDTimer = stateCD;
        
        if (stateCanChange)
            stateCDTimer -= Time.deltaTime;

        strafeCDTimer -= Time.deltaTime;

        if (stateCDTimer <= 0 && stateCanChange)
        {
            if (playerInRange)                      // Figuring out current state in terms of player location
            {
                if (playerCloseRange)
                    current = State.closeRange;
                else
                    current = State.normalRange;
            }
            else
                current = State.farRange;
        }
        
        if (current == State.normalRange)
        {
            Enemy_Bullet.speed = 10f * PlayerPrefs.GetFloat("Enemy_ATK_Speed(FACTOR)");
            Enemy_Gun.fireSpeed = 0.4f * PlayerPrefs.GetFloat("Enemy_ATK_Rate(FACTOR)");
            if (strafeCDTimer <= 0f)
            {
                strafeDirection = 0;
                strafeDirection = Random.Range(-1.0f, 1.0f);
                moveVelocity = new Vector2(strafeDirection * strafeSpd, 0f);
                strafeCDTimer = strafeCD;
            }

        }
        else if(current == State.farRange)
        {
            
            farCDTimer -= Time.deltaTime;
            stateCanChange = false;

            Enemy_Bullet.speed = 20f * PlayerPrefs.GetFloat("Enemy_ATK_Speed(FACTOR)");
            Enemy_Gun.fireSpeed = 0.1f * PlayerPrefs.GetFloat("Enemy_ATK_Rate(FACTOR)");
            // Decrease spread
            if (strafeCDTimer <= 0f)
            {
                strafeDirection = 0;
                strafeDirection = Random.Range(-1.0f, 1.0f);
                moveVelocity = new Vector2(strafeDirection * strafeSpd, 0f);
                strafeCDTimer = strafeCD;
            }

            if (farCDTimer <= 0f)
            {
                current = State.farMove;
                farCDTimer = farCD;
            }

        }
        else if (current == State.closeRange)
        {
            closeCDTimer -= Time.deltaTime;
            stateCanChange = false;

            Enemy_Bullet.speed = 7f * PlayerPrefs.GetFloat("Enemy_ATK_Speed(FACTOR)");
            Enemy_Gun.fireSpeed = 0.2f * PlayerPrefs.GetFloat("Enemy_ATK_Rate(FACTOR)");
            // Increase spread
            if (strafeCDTimer <= 0f)
            {
                strafeDirection = 0;
                strafeDirection = Random.Range(-1.0f, 1.0f);
                moveVelocity = new Vector2(strafeDirection * strafeSpd, 0f);
                strafeCDTimer = strafeCD;
            }
            
            if (closeCDTimer <= 0f)
            {
                current = State.closeMove;
                closeCDTimer = closeCD;
            }
        }
        else if(current == State.closeMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -retreatSpd * Time.deltaTime);
            if (strafeCDTimer <= 0f)
            {
                strafeDirection = 0;
                strafeDirection = Random.Range(-1.0f, 1.0f);
                moveVelocity = new Vector2(strafeDirection * strafeSpd, 0f);
                strafeCDTimer = strafeCD;
            }
            if (playerExitSpecialStatus)
            {
                playerExitSpecialStatus = false;
                stateCDTimer = stateCD;
                stateCanChange = true;
                current = State.normalRange;
            }
        }
        else if (current == State.farMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, approachSpd * Time.deltaTime);
            if (strafeCDTimer <= 0f)
            {
                strafeDirection = 0;
                strafeDirection = Random.Range(-1.0f, 1.0f);
                moveVelocity = new Vector2(strafeDirection * strafeSpd, 0f);
                strafeCDTimer = strafeCD;
            }
            if (playerExitSpecialStatus)
            {
                playerExitSpecialStatus = false;
                stateCDTimer = stateCD;
                stateCanChange = true;
                current = State.normalRange;
            }
        }


        avoidCDTimer_x -= Time.deltaTime;    // Countdown for avoiding projectile behaviour
        avoidCDTimer_y -= Time.deltaTime;
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Instantiate(enemy_hit, gameObject.transform.position, Quaternion.identity);
    }

    public void Avoid_x(float impact)
    {
        if (avoidCDTimer_x <= 0f)
        {
            moveVelocity += new Vector2(impact, 0f) * avoidSpd;
            avoidCDTimer_x = avoidCD;
        }
    }

    public void Avoid_y(float impact)
    {
        if (avoidCDTimer_y <= 0f)
        {
            moveVelocity += new Vector2(0f, impact) * avoidSpd;
            avoidCDTimer_y = avoidCD;
        }
    }
} 
