using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerFire : NetworkBehaviour
{
    PlayerControl _playerController;

    public PlayerFire(PlayerControl pl)
    {
        _playerController = pl;
    }

   [_playerController:Command]
   public void CmdAtesEtme()
    {
        GameObject mybullet = Instantiate(_playerController.Mermi, _playerController.MermiBase.transform.position, _playerController.MermiBase.rotation) as GameObject;
        mybullet.GetComponent<Rigidbody>().velocity = _playerController.transform.forward * _playerController.MermiHız;
        NetworkServer.Spawn(mybullet);
        Destroy(mybullet, 3f);       
    }
    public void FireControl()
    {
        _playerController.MermiCephanesi--;
        AudioSource.PlayClipAtPoint(_playerController.FireSound, _playerController.transform.position, 0.8f);
    }

}
