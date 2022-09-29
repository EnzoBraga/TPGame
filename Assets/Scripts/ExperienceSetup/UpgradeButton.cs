using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI upgradeName;

    public void Set(UpgradesData upgradeData){
        icon.sprite = upgradeData.icon;
        upgradeName.text = upgradeData.Name;
    }
}
