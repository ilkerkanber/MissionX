using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class TurretMermi : NetworkBehaviour
{
   
    [SerializeField] int turretMermiHasarı;
    private void OnCollisionEnter(Collision collision)
    {
        var Dusman = collision.gameObject.GetComponent<EnemyHealthBar>();
       
        if (collision.gameObject.tag == "Dusman")
        {   
            Dusman.Health(turretMermiHasarı);
        } 
      Destroy(gameObject);
    }
}
