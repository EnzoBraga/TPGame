using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private int missileDamage = 2;
    private Vector3 direction;
    private bool hitted = false;

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
        if(Time.frameCount % 6 == 0)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach (Collider2D hit in colliders)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(missileDamage);
                    hitted = true;
                    break;
                }
            }
            if (hitted)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDirection(float dirX, float dirY)
    {
        direction = new Vector3(dirX, 0f, 0f);
        if(dirX > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }
}
