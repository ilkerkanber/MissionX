﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildirgeKup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * 30);
    }
}
