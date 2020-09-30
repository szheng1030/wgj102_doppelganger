using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Destroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.31f);
    }
}
