using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class ObjectSpawner : NetworkBehaviour
{
    [SerializeField] GameObject[] Boxs;
    [SerializeField] float ObjectSpawnTime;
    float SpawnTime;
    private void Start()
    {
         SpawnTime = ObjectSpawnTime;
    }

    void Update()
    {
        ObjectSpawnTime -= Time.deltaTime;
        if (ObjectSpawnTime <= 0)
        {
            CmdObjectSpawn();
            ObjectSpawnTime = SpawnTime;
        }
    }
    [Command]
    void CmdObjectSpawn()
    {
        GameObject go = Instantiate(Boxs[Random.Range(0, 4)], transform.position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(go);
    }
}
