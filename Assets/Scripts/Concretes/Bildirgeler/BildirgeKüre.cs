using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BildirgeKüre : MonoBehaviour
{
    int secim=0;
    float zaman = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        Rotate();
    }
    void Rotate()
    {
        zaman -= Time.deltaTime;
        if (zaman <= 0)
        {
             secim = Random.Range(0, 4);
             zaman = 4;
        }
        switch (secim)
        {
            case 0:
                transform.Rotate(Vector3.up, Time.deltaTime * 50);
                break;
            case 1:
                transform.Rotate(-Vector3.up, Time.deltaTime * 50);
                break;
            case 2:
                transform.Rotate(-Vector3.left, Time.deltaTime * 50);
                break;
            case 3:
                transform.Rotate(Vector3.left, Time.deltaTime * 50);
                break;
        }
    }
}
