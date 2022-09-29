using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock
}

[CreateAssetMenu(fileName = "UpgradesData", menuName = "UpgradesData.cs/UpgradesData", order = 0)]
public class UpgradesData : ScriptableObject {
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
}