using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class Enemy_Gun : MonoBehaviour
{
    public GameObject bullet_L4;
    public GameObject bullet_L3;
    public GameObject bullet_L2;
    public GameObject bullet_L;
    public GameObject bullet_M;
    public GameObject bullet_R;
    public GameObject bullet_R2;
    public GameObject bullet_R3;
    public GameObject bullet_R4;
    private Transform enemyPos;

    public static float fireSpeed;
    private float fireCD;

    void Start()
    {
        enemyPos = GetComponent<Transform>();
        fireSpeed = 0.5f * PlayerPrefs.GetFloat("Enemy_ATK_Rate(FACTOR)");
        fireCD = 1.2f;
    }

    void Update()
    {
        fireCD -= Time.deltaTime;
        if (Enemy.current == State.normalRange)
        {
            if (fireCD < 0f)
            {
                Instantiate(bullet_L2, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_L, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_M, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R2, enemyPos.position, Quaternion.identity);
                fireCD = fireSpeed;
            }
        }
        if (Enemy.current == State.farRange || Enemy.current == State.farMove)
        {
            if(fireCD < 0f)
            {
                Instantiate(bullet_L, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_M, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R, enemyPos.position, Quaternion.identity);
                fireCD = fireSpeed;
            }
        }
        if (Enemy.current == State.closeRange || Enemy.current == State.closeMove)
        {
            if (fireCD < 0f)
            {
                Instantiate(bullet_L4, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_L3, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_L2, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_L, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_M, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R2, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R3, enemyPos.position, Quaternion.identity);
                Instantiate(bullet_R4, enemyPos.position, Quaternion.identity);
                fireCD = fireSpeed;
            }
        }

    }
}
