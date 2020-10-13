﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp = 100;
    public float speed;
    public GameObject cam;
    public float resetDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

        if((transform.position.x - cam.transform.position.x) > 25)
        {
            transform.position = new Vector3(cam.transform.position.x - resetDistance, transform.position.y, transform.position.z);
        }
        if(hp <= 0)
        {
            Destroy(this);
        }
    }
}
