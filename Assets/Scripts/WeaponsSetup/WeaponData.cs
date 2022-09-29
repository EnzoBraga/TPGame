using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats{
    public int damage;
    public float attackCooldown;

    public WeaponStats(int damage, float attackCooldown){
        this.damage = damage;
        this.attackCooldown = attackCooldown;
    }
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponData.cs/WeaponData", order = 0)]
public class WeaponData : ScriptableObject {
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
}