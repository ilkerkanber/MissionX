using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Obsolete]
public class EventControl : NetworkBehaviour
{
    PlayerControl _playerControl;
    ObjectPrices _objectPrices;
   
    public GameObject TradeMenuEntered;
    public GameObject[] Turret;
   
    public EventControl(ObjectPrices ob)
    {
        _objectPrices = ob;
    }
    private void Awake()
    {
        _playerControl = GetComponent < PlayerControl >();
        _objectPrices = GameObject.FindGameObjectWithTag("ObjectPrices").GetComponent<ObjectPrices>();
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }
        KeyPressedControl();    
    }
   public void KeyPressedControl()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            TradeMenuEnter();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            TradeMenuExit();
        }
    }
   public void TradeMenuEnter()
    {
        if (TradeMenuEntered.active == true) {
            TradeMenuExit();
        }
        else { 
            TradeMenuEntered.SetActive(true);
            Cursor.visible = true;
        }
    }
   public void TradeMenuExit()
    {
        TradeMenuEntered.SetActive(false);
        Cursor.visible = false;
    }

    //Turret 0
    //TripleTurret 1
    [Command]
    public void CmdSpawnTurret(int TurretTürü)
    {
        var go = Instantiate(Turret[TurretTürü], transform.position + new Vector3(1, 0, 0), Quaternion.identity) as GameObject;
        NetworkServer.SpawnWithClientAuthority(go,this.gameObject);
    }
   public void BuyTurret()
    {
        Debug.Log(_objectPrices.TurretBulletPrice);
        Debug.Log(_playerControl.Money);

        if (isLocalPlayer)
        {
            if (_playerControl.Money >= _objectPrices.TurretPrice) {
                _playerControl.Money -= _objectPrices.TurretPrice;
                CmdSpawnTurret(0);
            }
        }
    }
  public void BuyTripleTurret()
    {
        if (isLocalPlayer)
        {
            if (_playerControl.Money >= _objectPrices.TripleTurretPrice) {
                _playerControl.Money -= _objectPrices.TripleTurretPrice;
                CmdSpawnTurret(1);
            }    
        }
    }
   public void BuyPlayerBullet()
    {
        if (isLocalPlayer)
        {
            if (_playerControl.Money >= _objectPrices.PlayerBulletPrice) {
                _playerControl.Money -= _objectPrices.PlayerBulletPrice;
                _playerControl.MermiCephanesi += 50;
            }       
        }
    }
   public void BuyTurretBullet()
    {
        if (isLocalPlayer)
        {
           if( _playerControl.Money >= _objectPrices.TurretBulletPrice) {
               _playerControl.Money -= _objectPrices.TurretBulletPrice;
                _playerControl.TurretCephanesi += 100;
            }   
        }
    }

}
