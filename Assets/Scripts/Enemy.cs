using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp = 1;
    [SerializeField] private GameObject target;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float moveSpeed;
    private Vector2 movement;


    private void Awake()
    {
        target = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(target != null){
            if(target.GetComponent<Player>().isAlive){
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            }

            if (!target.GetComponent<Player>().isAlive)
            {
                Destroy(gameObject);
            }
        }else{
            Destroy(gameObject);
        }
        _rigidbody.velocity = new Vector2(0,0);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject == target && target.GetComponent<Player>().hp > 0){
            target.GetComponent<Player>().TakeDamage();
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
}
