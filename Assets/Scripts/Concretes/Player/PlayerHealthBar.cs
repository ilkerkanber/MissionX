using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Obsolete]
public class PlayerHealthBar : NetworkBehaviour
{
    Box _box;

    public TextMeshProUGUI[] dusmanSayılarıText;
    public RectTransform UIGuncelCan;
    public RectTransform BosCan;
    public RectTransform GuncelCanCubugu; 
    public GameObject UI;
    NetworkStartPosition[] dogmaNoktaları;
    int []Dusmanlar; 
   
    [SyncVar(hook = "CanDegisikligi")]
    public int güncelCan;
    int FirstCan;

    void Start()
    { 
        CanBarSetup();
        UIManager();
        dogmaNoktaları=FindObjectsOfType<NetworkStartPosition>();
    }

    void Update()
    {  
        DusmanSayılarıSetup(3);  
    }
    //Server işlemi
    [ClientRpc]
    void RpcRespawn()
    {   
        
        if (isLocalPlayer || isServer)
        {
           Vector3 oyuncununDogmaNoktası = dogmaNoktaları[Random.Range(0, dogmaNoktaları.Length)].transform.position;
           transform.position = oyuncununDogmaNoktası;
        }
     }

    public void HealthDecrease(int Damage)
    {  
        if (!isServer)
        {
            return;
        }
        
        güncelCan -= Damage;
        if(güncelCan<=0)
        {
            RpcRespawn();
            güncelCan = 100;
        }
    }
    
    public void FullHealth()
    {
        if (!isServer)
        {
            return;
        }
        güncelCan = 100;
    }
    void CanBarSetup()
    {
        FirstCan = güncelCan;
        BosCan.sizeDelta = new Vector2(FirstCan, BosCan.sizeDelta.y);
        GuncelCanCubugu.sizeDelta = new Vector2(FirstCan, GuncelCanCubugu.sizeDelta.y);
    }
    void CanDegisikligi(int GüncelCanDegeri)
    {
        UIGuncelCan.sizeDelta = new Vector2(GüncelCanDegeri, UIGuncelCan.sizeDelta.y);
        GuncelCanCubugu.sizeDelta = new Vector2(GüncelCanDegeri, GuncelCanCubugu.sizeDelta.y);
    }
    void DusmanSayılarıSetup(int ToplamDusmanTürü)
    {
        Dusmanlar = new int[ToplamDusmanTürü+1];
        for (int i = 0; i < ToplamDusmanTürü+1; i++)
        {
            Dusmanlar[i] = 0;
        }
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Dusman"))
        {
         
            if (gameObject.name == "Arkeoid(Clone)")
                {
                    Dusmanlar[0]++;
                }
                else if (gameObject.name == "LittleArkeoid(Clone)")
                {
                    Dusmanlar[1]++;
                }     
                else if (gameObject.name == "Bombear(Clone)")
                {
                    Dusmanlar[2]++;
                }
                 //KADEME
                //Toplam Dusman Sayısı
                Dusmanlar[3]++;
            }
        
        dusmanSayılarıText[0].text = Dusmanlar[0].ToString();
        dusmanSayılarıText[1].text = Dusmanlar[1].ToString();
        dusmanSayılarıText[2].text = Dusmanlar[2].ToString();
        dusmanSayılarıText[3].text = Dusmanlar[3].ToString();
    }
    void UIManager()
    {
      if (isLocalPlayer){
            UI.SetActive(true);
            Cursor.visible = false;
        }
        else { UI.SetActive(false); }
    }
   
}
