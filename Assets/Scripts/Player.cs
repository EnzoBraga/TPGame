using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 100;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public Vector2 lastMovement;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        lastMovement.x = 1f;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0)
        {
            lastMovement.x = movement.x;
            lastMovement.y = 0f;
        }
        else if(movement.y != 0)
        {
            lastMovement.y = movement.y;
            lastMovement.x = 0f;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TakeDamage()
    {
        hp--;
    }
}
