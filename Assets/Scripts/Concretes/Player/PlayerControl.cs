using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerControl : NetworkBehaviour
{
    PlayerMove _playerMove;
    PlayerFire _playerFire;
    Box _box;
    
    [SerializeField] Transform mermiBase;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject mermi;
    [SerializeField] GameObject TradeUI;
    [SerializeField] AudioClip fire;
    [SerializeField] float playerHız, mermiHız;

    public int MermiCephanesi=50;
    public int Money=150;
    public int TurretCephanesi=100;

    public GameObject Cam => cam;
    public GameObject Mermi => mermi;
    public float PlayerHız => playerHız;
    public float MermiHız => mermiHız;
    public Transform MermiBase => mermiBase;
    public AudioClip FireSound => fire;

    public float camx = 0, camy = 0;
  
    private void Awake()
    {
        _playerFire = new PlayerFire(this);
        _playerMove = new PlayerMove(this);
    }
   
    void Start()
    {
        _playerMove.Camera();
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }

        if (Input.GetKeyDown(KeyCode.Mouse0) && MermiCephanesi > 0 && TradeUI.active!=true)
        {
             CmdFire();
            _playerFire.FireControl();
        }
        _playerMove.Mouse();
    }
    
    void FixedUpdate()
    {
        _playerMove.Move();  
    }

    [Command]
    void CmdFire()
    {
        _playerFire.CmdAtesEtme();
    }
 
    private void OnTriggerStay(Collider other)
    {
        if (!isLocalPlayer) { return; }

        if (other.gameObject.GetComponentInParent<Turret>() == null) { return; }

            var turretPlace = other.gameObject.GetComponentInParent<Turret>();
            if (turretPlace.gameObject.tag == "Turret")
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    if (hasAuthority)
                    {
                        turretPlace.CmdSetMermi(TurretCephanesi);
                        TurretCephanesi = 0;
                    }
                }
            }

    }



}
