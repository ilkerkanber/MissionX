
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

[System.Obsolete]
public class EnemyAI : NetworkBehaviour
{
    EnemyController _EnemyController;

    Vector3 poz;
    int SelectDirection = 0;
    float DirectionRelTime = 3;
 
    
    public EnemyAI(EnemyController enemyContr)
    {
        _EnemyController = enemyContr;
    }
    
    public void AIMOD(int state)
    {
         poz = new Vector3(_EnemyController.TargetObjects[state].transform.position.x, _EnemyController.transform.position.y, _EnemyController.TargetObjects[state].transform.position.z);
        _EnemyController.transform.LookAt(poz);
        _EnemyController.transform.position = Vector3.MoveTowards(_EnemyController.transform.position, _EnemyController.TargetObjects[state].transform.position, (_EnemyController.EnemySpeed / 10) * Time.deltaTime);       
    }
        
    public void RandomWalk() {
        
        DirectionRelTime -= Time.deltaTime;
        if (DirectionRelTime <= 0)
        {
           SelectDirection = Random.Range(0, 2);
            DirectionRelTime = 5;
        } 

       switch(SelectDirection)
        {
            case 0:
               _EnemyController.transform.Rotate(Vector3.up ,Time.deltaTime * 30);
                break;
            case 1:
                _EnemyController.transform.Rotate(-Vector3.up, Time.deltaTime * 30);
                break;
        }

        _EnemyController.transform.Translate(Vector3.forward * Time.deltaTime);
    }

   
   

}
