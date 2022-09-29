using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;
    public WeaponStats weaponStats;

    public float attackCooldown = 1f;
    private float timer;

    public void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0){
            Attack();
            timer = attackCooldown;
        }
    }

    public virtual void SetData(WeaponData data){
        weaponData = data;
        attackCooldown = weaponData.stats.attackCooldown;

        weaponStats = new WeaponStats(data.stats.damage, data.stats.attackCooldown);
    }

    public abstract void Attack();
}
