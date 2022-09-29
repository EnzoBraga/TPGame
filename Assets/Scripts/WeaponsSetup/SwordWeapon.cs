using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : WeaponBase
{
    [SerializeField] private GameObject leftSwordAttack;
    [SerializeField] private GameObject rightSwordAttack;
    [SerializeField] private GameObject upSwordAttack;
    [SerializeField] private GameObject downSwordAttack;

    [SerializeField] private Player playerMovement;
    [SerializeField] private Vector2 attackSize = new Vector2(4f, 2f);

    private void Awake() {
        playerMovement = GameObject.Find("Player").GetComponent<Player>();
    }

    public override void Attack()
    {

        if (playerMovement.lastMovement.x > 0)
        {
            rightSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightSwordAttack.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else if(playerMovement.lastMovement.x < 0)
        {
            leftSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftSwordAttack.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        
        if (playerMovement.lastMovement.y > 0)
        {
            upSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(upSwordAttack.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
        else if (playerMovement.lastMovement.y < 0)
        {
            downSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(downSwordAttack.transform.position, attackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            Enemy enemy = colliders[i].GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(weaponStats.damage);
            }
        }
    }
}
