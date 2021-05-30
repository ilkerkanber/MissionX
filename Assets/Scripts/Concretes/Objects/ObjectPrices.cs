using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class ObjectPrices : MonoBehaviour
{
    
    [SerializeField] int turretPrice;
    [SerializeField] int tripleTurretPrice;
    [SerializeField] int turretBulletPrice;
    [SerializeField] int playerBulletPrice;

    public int TurretPrice => turretPrice;
    public int TripleTurretPrice => tripleTurretPrice;
    public int TurretBulletPrice => turretBulletPrice;
    public int PlayerBulletPrice => playerBulletPrice;
  
}
