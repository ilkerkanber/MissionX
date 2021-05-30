using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Obsolete]
public class PlayerMenu : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI mermiText, turretMermiText, moneyText;
    
    private void Update()
    {
        UITexts();
    }

    private void UITexts()
    {
        var PlayerControl = gameObject.GetComponentInParent<PlayerControl>();
        moneyText.SetText(PlayerControl.Money.ToString());
        turretMermiText.SetText(PlayerControl.TurretCephanesi.ToString());
        mermiText.SetText(PlayerControl.MermiCephanesi.ToString());
    }




}
