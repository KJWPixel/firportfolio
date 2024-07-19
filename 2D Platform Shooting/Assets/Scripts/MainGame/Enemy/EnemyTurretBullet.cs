using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] float bulletDamage;

    SpriteRenderer spriteRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            PlayerControll player = collision.GetComponent<PlayerControll>();
            player.Hit(bulletDamage);
        }

        if(collision.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

}
