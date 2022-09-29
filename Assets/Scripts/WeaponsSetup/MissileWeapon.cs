using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : WeaponBase
{
    [SerializeField] private GameObject missilePrefab;
    public int weaponLevel = 1;
    private GameObject thrownMissile;

    public override void Attack()
    {
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

    private void InstantiateMissile(float xPos, float yPos)
    {
        thrownMissile = Instantiate(missilePrefab);
        thrownMissile.transform.position = transform.position;
        thrownMissile.GetComponent<MissileProjectile>().SetDirection(xPos, yPos);
    }
}
