using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class EnemyController : MonoBehaviour
{
    EnemyAI _EnemyAI;
    
    [SerializeField] GameObject enemyWeapon;
    [SerializeField] float enemySpeed;
    [SerializeField] float hareketlenmeSınırı = 200f, saldırıSınırı=10f;
    public float EnemySpeed => enemySpeed;
    public GameObject EnemyWeapon => enemyWeapon;
    public GameObject[] TargetObjects { get; private set; }
    public bool Engel { get; private set; }
    public bool Attack { get; private set; }

    float[] PlayersWithDistances;

    private void Awake()
    {
        _EnemyAI = new EnemyAI(this);
    }
    private void Start()
    {
        PlayerSearch();
    }

    void Update()
    {   
        PlayerSearch();
    }
    private void FixedUpdate()
    {
        EnemyMoveRules();
        EnemyAttackRules();
    }

    void EnemyMoveRules()
    {
        if (TargetObjects.Length == 0 || Engel == true)
        {
            _EnemyAI.RandomWalk();
        }

        else if (TargetObjects.Length == 1)
        {
            if (PlayersWithDistances[0] < hareketlenmeSınırı)
            {
                _EnemyAI.AIMOD(0);
            }
            else
            {
                _EnemyAI.RandomWalk();
            }
        }

        else if (TargetObjects.Length == 2)
        {
            if (PlayersWithDistances[0] < PlayersWithDistances[1] && PlayersWithDistances[0] < hareketlenmeSınırı)
            {
                _EnemyAI.AIMOD(0);
            }
            else if (PlayersWithDistances[1] < PlayersWithDistances[0] && PlayersWithDistances[1] < hareketlenmeSınırı)
            {
                _EnemyAI.AIMOD(1);
            }
            else
            {
                _EnemyAI.RandomWalk();
            }
        }
    }
    void EnemyAttackRules()
    {
        switch (TargetObjects.Length)
        {
            case 0:
                    Attack = false;
                break;

            case 1:
                if (PlayersWithDistances[0] < saldırıSınırı){ 

                    Attack = true;
                }
                else
                {
                    Attack = false;
                }
                break;

            case 2:
                if ((PlayersWithDistances[0] < saldırıSınırı) || (PlayersWithDistances[1] < saldırıSınırı)){ 
                
                    Attack = true;
                }
                else { 
                    Attack = false;
                }
                break;
        }
        
    
       
    }
    void PlayerSearch()
    {
        int döngü = 0;
     
        TargetObjects= GameObject.FindGameObjectsWithTag("Player");
        PlayersWithDistances = new float[TargetObjects.Length];
        foreach(GameObject x in TargetObjects)
        {
            PlayersWithDistances[döngü] = Vector3.Distance(transform.position, x.transform.position);
            döngü++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Engel = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Engel = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Engel")
        {
            Engel = false;
        }
    }
}
