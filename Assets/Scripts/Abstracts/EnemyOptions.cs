using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public abstract class EnemyOptions : NetworkBehaviour
{
    EnemyController _EnemyController;

    [SerializeField] AudioClip FireSound;
    [SerializeField] Transform[] weaponBase;
    [SerializeField] float weaponSpeed, reloadWeaponTime;
    [SerializeField] float soundTotalTime;
    [SerializeField] float firstAttackCount;
    float reloadWeaponStart;

    private void Awake()
    {
        _EnemyController = GetComponent<EnemyController>();   
    }
    void Start()
    {
        reloadWeaponStart = reloadWeaponTime;
        reloadWeaponTime = 0;
    }
    private void FixedUpdate()
    {
        if (_EnemyController.Attack)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (reloadWeaponTime <= 0)
        {
            for (int i = 1; i <= firstAttackCount; i++)
            {
                CmdZehir();
            }
            AudioSource.PlayClipAtPoint(FireSound, transform.position, soundTotalTime);
            reloadWeaponTime = reloadWeaponStart;
        }
        reloadWeaponTime -= Time.deltaTime;
    }

    [Command]
    public void CmdZehir()
    {
        int place = Random.Range(0, weaponBase.Length);
        GameObject agı = Instantiate(_EnemyController.EnemyWeapon, weaponBase[place].transform.position, weaponBase[place].rotation) as GameObject;
        agı.GetComponent<Rigidbody>().velocity = transform.forward * weaponSpeed;
        NetworkServer.Spawn(agı);
        Destroy(agı, 3);
    }
}
