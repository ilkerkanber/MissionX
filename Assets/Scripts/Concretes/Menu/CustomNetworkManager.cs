using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class CustomNetworkManager : NetworkManager
  {
  
    public void Host()
    {
        GameObject Menu = GameObject.Find("Menu");
        Menu.SetActive(false);
        base.StartHost();
    }
  public void Client()
    {
        GameObject Menu = GameObject.Find("Menu");
        Menu.SetActive(false);
        base.StartClient();
    }
  }
