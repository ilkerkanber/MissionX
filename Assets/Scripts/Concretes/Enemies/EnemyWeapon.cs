using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]

public class EnemyWeapon : NetworkBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] int Damage;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject collision)
    {
        var Player = collision.GetComponent<PlayerHealthBar>();
        if (collision.gameObject.tag == "Player")
        {
            Player.HealthDecrease(Damage);
        }
    }
}
