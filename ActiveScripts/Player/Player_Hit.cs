using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.16f);
    }
}
