using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    private Transform playerPos;

    public float fireSpeed;
    private float fireCD;

    void Start()
    {
        fireSpeed = PlayerPrefs.GetFloat("Player_ATK_Rate");
        playerPos = GetComponent<Transform>();
        fireCD = fireSpeed;
    }

    void Update()
    {
        fireCD -= Time.deltaTime;

        if(Input.GetMouseButton(0))
        {
            if (fireCD < 0f)
            {
                Instantiate(bullet, playerPos.position, Quaternion.identity);
                fireCD = fireSpeed;
            }
        }
    }

}
