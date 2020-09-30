using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    private Transform bar;
    private float total_hp;

    // Start is called before the first frame update
    void Start()
    {
        total_hp = PlayerPrefs.GetFloat("Enemy_HP");
        bar = GameObject.Find("Enemy_HPBar_offset").transform;
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(Enemy.hp / total_hp, 1f);
    }
}
