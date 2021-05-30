using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class Mermi : NetworkBehaviour
{
    public int Price;
    [SerializeField] int MermiHasarı;
    private void OnCollisionEnter(Collision collision)
    {   var Dusman= collision.gameObject.GetComponent<EnemyHealthBar>();
        Destroy(gameObject);
        if (collision.gameObject.tag == "Dusman")
        {
            Dusman.Health(MermiHasarı);
        }
     }  
}
