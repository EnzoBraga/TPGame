using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] private int missileDamage = 1;
    private Vector3 direction;
    
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
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void SetDirection(float dirX, float dirY)
    {
        direction = new Vector3(dirX, dirY, 0f);
        if(dirX > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
        if(dirY > 0 && dirX == 0){
            transform.Rotate (Vector3.forward * -90);
        }else if(dirY < 0 && dirX == 0){
            transform.Rotate(Vector3.forward*90);
        }else if((dirY > 0 && dirX > 0) || (dirY < 0 && dirX < 0)){
            transform.Rotate(Vector3.forward*45);
        }else if((dirY > 0 && dirX < 0) || (dirY < 0 && dirX > 0)){
            transform.Rotate(Vector3.forward*-45);
        }
    }
}