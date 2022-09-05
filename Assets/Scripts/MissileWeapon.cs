using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float attackCooldown = 2.5f;
    public int weaponLevel = 1;
    private float attackTimer;
    private GameObject thrownMissile;

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Attack(weaponLevel);
        }
    }

    private void Attack(int weaponLevel)
    {
        attackTimer = attackCooldown;
        switch (weaponLevel)
        {
            case 1:
                InstantiateMissile(0f, 1f );
            break;
            case 2:
                InstantiateMissile(0f, 1f );
                InstantiateMissile(1f, 0f );
            break;
            case 3:
                InstantiateMissile(0f, 1f );
                InstantiateMissile(1f, 0f );
                InstantiateMissile(0f, -1f );
            break;
            case 4:
                InstantiateMissile(0f, 1f );
                InstantiateMissile(1f, 0f );
                InstantiateMissile(0f, -1f );
                InstantiateMissile(-1f, 0f );
            break;
            case 5:
                InstantiateMissile(0f, 1f );
                InstantiateMissile(1f, 0f );
                InstantiateMissile(0f, -1f );
                InstantiateMissile(-1f, 0f );

                InstantiateMissile(1f, 1f );
                InstantiateMissile(1f, -1f );
                InstantiateMissile(-1f, -1f );
                InstantiateMissile(-1f, 1f );
            break;
            default:
                InstantiateMissile(0f, 1f );
            break;
        }
    }

    void InstantiateMissile(float xPos, float yPos)
    {
        thrownMissile = Instantiate(missilePrefab);
        thrownMissile.transform.position = transform.position;
        thrownMissile.GetComponent<MissileProjectile>().SetDirection(xPos, yPos);
    }
}
