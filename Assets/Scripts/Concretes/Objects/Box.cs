using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class Box : NetworkBehaviour
{
    PlayerControl _playerControl;
    PlayerHealthBar _playerHealthBar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerControl = collision.collider.GetComponent<PlayerControl>();
            _playerHealthBar = collision.collider.GetComponent<PlayerHealthBar>();

            if (this.gameObject.name == "CanPaket(Clone)") {

                _playerHealthBar.güncelCan = 100;
            }
            else if (this.gameObject.name == "MermiPaket(Clone)")
            {
                _playerControl.MermiCephanesi = _playerControl.MermiCephanesi + 50;
            }
            else if (this.gameObject.name == "TurretMermiPaket(Clone)")
            {
                _playerControl.TurretCephanesi = _playerControl.TurretCephanesi + 100;
            }
            else if (this.gameObject.name == "MoneyPaket(Clone)")
            {
                _playerControl.Money = _playerControl.Money + 75;
            }

            Destroy(this.gameObject);
        }
        
    }
}
