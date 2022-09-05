using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileWeapon : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private float attackCooldown = 2.5f;
    [SerializeField] private Player playerMovement;
    private float attackTimer;

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        attackTimer = attackCooldown;
        GameObject thrownMissile = Instantiate(missilePrefab);
        thrownMissile.transform.position = transform.position;
        thrownMissile.GetComponent<MissileProjectile>().SetDirection(playerMovement.lastMovement.x, playerMovement.lastMovement.y);
    }
}
