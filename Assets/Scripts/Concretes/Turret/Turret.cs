using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class Turret : NetworkBehaviour
{
    [SerializeField] AudioClip Fire;
    public TextMeshProUGUI TurretTotalBulletText;
    public GameObject[] Dusmanlar;
    public GameObject turretMermi;
    public Transform[] mermiBase;
    public int Price;
    public float Hedef;
    public float[] Mesafeler;
    public float SaldırıSınırı, mermiHız, ReloadSüresi;

    [SyncVar(hook = "MermiInfo")]
    [SerializeField] int ToplamMermi;

    Vector3 poz;
    float enkucukMesafeDegeri = 100000, zaman = 5, relZaman = 0;
    int enkucukDizi = 0, karar = 0;

    private void Start()
    {
    }
    void Update()
    {
        DusmanlarıBul();
    }
    void DusmanlarıBul()
    {
        Dusmanlar = GameObject.FindGameObjectsWithTag("Dusman");

        if (Dusmanlar.Length >= 1)
        {
            enkucukMesafeDegeri = 1000;
            Mesafeler = new float[Dusmanlar.Length];

            for (int i = 0; i < Dusmanlar.Length; i++)
            {
                Mesafeler[i] = Vector3.Distance(transform.position, Dusmanlar[i].transform.position);
            }
            EnYakın();
        }
    }
    void EnYakın()
    {
        for (int i = 0; i < Mesafeler.Length; i++)
        {
            if (enkucukMesafeDegeri > Mesafeler[i])
            {
                enkucukMesafeDegeri = Mesafeler[i];
                enkucukDizi = i;
            }
        }

        if (enkucukMesafeDegeri < SaldırıSınırı)
        {
            poz = new Vector3(Dusmanlar[enkucukDizi].transform.position.x, transform.position.y, Dusmanlar[enkucukDizi].transform.position.z);
            transform.LookAt(poz);
            Hedef = Vector3.Distance(transform.position, Dusmanlar[enkucukDizi].transform.position);
            relZaman += Time.deltaTime;
            if (!isServer)
            {
                return;
            }
            if (ToplamMermi < 0) { ToplamMermi = 0; }
            if (relZaman > ReloadSüresi && ToplamMermi > 0)
            {
                CmdSaldır(mermiBase.Length);
                relZaman = 0;
                AudioSource.PlayClipAtPoint(Fire, transform.position, 1.5f);
            }
        }
        else { RastgeleBakın(); }
    }
    [Command]
    public void CmdSaldır(int UretilenMermiSayısı)
    {
        GameObject[] mermi = new GameObject[UretilenMermiSayısı];
        for (int i = 0; i < UretilenMermiSayısı; i++)
        {
            ToplamMermi--;
            mermi[i] = Instantiate(turretMermi, mermiBase[i].transform.position, mermiBase[i].rotation) as GameObject;
            mermi[i].GetComponent<Rigidbody>().velocity = transform.forward * mermiHız;
            NetworkServer.Spawn(mermi[i]);
            Destroy(mermi[i], 3);
        }

    }
    void RastgeleBakın()
    {
        zaman -= Time.deltaTime;
        if (zaman <= 0)
        {
            karar = Random.Range(0, 2);
            zaman = 5;
        }

        switch (karar)
        {
            case 0:
                transform.Rotate(Vector3.up, Time.deltaTime * 50);
                break;
            case 1:
                transform.Rotate(-Vector3.up, Time.deltaTime * 50);
                break;
        }
    }
    void MermiInfo(int tMermi)
    {
        TurretTotalBulletText.SetText(tMermi.ToString());
    }
 
    [Command]
    public void CmdSetMermi(int count)
    {
        ToplamMermi += count;
    }
   
}
