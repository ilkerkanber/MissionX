using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class EnemySpawner : NetworkBehaviour
{
    float zaman;
    bool spawn = false;
    public int KADEME = 1;
    public GameObject[] dusmanPrefab;
    public Transform[] enemySpawnPoints;
    public GameObject winObject;
    
    void Start()
    {
        zaman = 0;
    }
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman >= 7 && spawn == false)
        {
            if (KADEME == 1)   { Asama1(); }
            else if (KADEME == 2) { Asama2(); }
            else if (KADEME == 3) { Asama3(); }
            else if (KADEME == 4) { Asama4(); }
            else if (KADEME == 5) { Asama5(); }
            else if (KADEME == 6) { Asama6(); }
            else if (KADEME == 7) { Asama7(); }
            else if (KADEME == 8) { Asama8(); }
            else if (KADEME == 9) { Asama9(); }
            else if (KADEME == 10) { Asama10(); }
            else if (KADEME == 11) { Asama11(); }
            else if (KADEME >= 12)
            {
                winObject.SetActive(true);
            }

        }
        if (spawn == true && GameObject.FindGameObjectsWithTag("Dusman").Length == 0){
            zaman = 0;
            spawn = false;
            KADEME++;
        }
    }
    void Spawn(int DusmanTürü,int DusmanSayısı)
    {
        for (int i = 1; i <= DusmanSayısı; i++)
        {                
        Quaternion dogmaDonusu = Quaternion.Euler(0, Random.Range(0, 180), 0);
        GameObject dusman = Instantiate(dusmanPrefab[DusmanTürü], enemySpawnPoints[Random.Range(0,10)].transform.position, dogmaDonusu) as GameObject;
        NetworkServer.Spawn(dusman);
        }
        spawn = true;
    }
    //EnemyCodes
    //Arkeoid 0
    //Bombear 1
    //LittleArkeoid 2
    void Asama1() {

        Spawn(0, 10);
    }
    void Asama2() {
        
        Spawn(0, 15);
        Spawn(2, 5);
    }
    void Asama3() { 
        
        Spawn(0, 20);
        Spawn(2, 10);
    }
    void Asama4() {
        Spawn(0, 30);
        Spawn(2, 15);
    }
    void Asama5() {
        Spawn(0, 50); 
    }
    void Asama6()
    {
        Spawn(2, 25);
    }
    void Asama7()
    {
        Spawn(0, 30);
        Spawn(1, 3);
    }
    void Asama8()
    {
        Spawn(0, 30);
        Spawn(1, 3);
        Spawn(2, 15);
    }
    void Asama9()
    {
        Spawn(0, 50);
        Spawn(1, 5);
    }
    void Asama10()
    {
        Spawn(2, 30);
        Spawn(1, 5);
    }
    void Asama11()
    {
        Spawn(0, 20);
        Spawn(1, 7);
        Spawn(2, 50);
    }





}
