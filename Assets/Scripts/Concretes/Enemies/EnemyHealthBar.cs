using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class EnemyHealthBar : NetworkBehaviour
{
    public RectTransform GuncelCanCubugu;
    public RectTransform BosCan;

    [SyncVar(hook = "DusmanCanDegisikligi")]
    [SerializeField] int güncelCanDusman;
    int FirstCan;
    void Start()
    {
        CanBarSetup();
    }
    public void Health(int Damage)
    {
        if (!isServer) { return; }
        güncelCanDusman -= Damage;

        if (güncelCanDusman <= 0)
        {
            Destroy(gameObject);
        }
    }
    void CanBarSetup()
    {
        FirstCan = güncelCanDusman;
        BosCan.sizeDelta = new Vector2(FirstCan, BosCan.sizeDelta.y);
        GuncelCanCubugu.sizeDelta = new Vector2(FirstCan, GuncelCanCubugu.sizeDelta.y);
    }
    void DusmanCanDegisikligi(int GüncelCanDegeri)
    {
        GuncelCanCubugu.sizeDelta = new Vector2(GüncelCanDegeri, GuncelCanCubugu.sizeDelta.y);
    }
    
}
