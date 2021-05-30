using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerMove : NetworkBehaviour
{
  
    PlayerControl _playerControl;
    public PlayerMove(PlayerControl pl)
    {
        _playerControl = pl;
    }
    public void Camera()
    {
        if (_playerControl.isLocalPlayer)
        {
            _playerControl.Cam.SetActive(true);
        }
        else 
        {
            _playerControl.Cam.SetActive(false); 
        }
    }
    
    public void Move()
    {
        if (!_playerControl.isLocalPlayer)
        { 
            return; 
        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * (_playerControl.PlayerHız / 10);
        float z = Input.GetAxis("Vertical") * Time.deltaTime * (_playerControl.PlayerHız/ 10);
        _playerControl.transform.Translate(x, 0, z);
    }
    public void Mouse()
    {
        _playerControl.camx += (3 * Input.GetAxis("Mouse X"));
        _playerControl.camy -= (Input.GetAxis("Mouse Y"));

        _playerControl.Cam.transform.eulerAngles = new Vector3(_playerControl.camy, _playerControl.camx, 0f);
        _playerControl.transform.eulerAngles = new Vector3(_playerControl.camy, _playerControl.camx, 0f);
    }

}
