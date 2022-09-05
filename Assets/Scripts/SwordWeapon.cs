using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{
    [SerializeField] private GameObject leftSwordAttack;
    [SerializeField] private GameObject rightSwordAttack;
    [SerializeField] private GameObject upSwordAttack;
    [SerializeField] private GameObject downSwordAttack;
    [SerializeField] private float attackCooldown = 2.5f;
    [SerializeField] private float attackTickTime = 1.5f;
    [SerializeField] private int swordDamage = 1;

    private float attackTimer;
    private float tickTimer;
    private bool _enabled = false;

    [SerializeField] private Player playerMovement;
    [SerializeField] private Vector2 swordAttackSize = new Vector2(4f, 2f);

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if(attackTimer <= 0 && !_enabled)
        {
            Attack();
        }

        if (_enabled)
        {
            tickTimer -= Time.deltaTime;
            if(tickTimer <= 0)
            {
                tickTimer = attackTickTime;
                _enabled = false;
                leftSwordAttack.SetActive(false);
                rightSwordAttack.SetActive(false);
                upSwordAttack.SetActive(false);
                downSwordAttack.SetActive(false);
            }
        }
    }

    private void Attack()
    {
        attackTimer = attackCooldown;
        _enabled = true;

        if (playerMovement.lastMovement.x > 0)
        {
            rightSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightSwordAttack.transform.position, swordAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else if(playerMovement.lastMovement.x < 0)
        {
            leftSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftSwordAttack.transform.position, swordAttackSize, 0f);
            ApplyDamage(colliders);
        }
        
        if (playerMovement.lastMovement.y > 0)
        {
            upSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(upSwordAttack.transform.position, swordAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else if (playerMovement.lastMovement.y < 0)
        {
            downSwordAttack.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(downSwordAttack.transform.position, swordAttackSize, 0f);
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
                enemy.TakeDamage(swordDamage);
            }
        }
    }
}
