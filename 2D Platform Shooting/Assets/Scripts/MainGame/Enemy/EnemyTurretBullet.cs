using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] float bulletDamage;

    public bool bulletDirCheck;

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
        //TurrentEnemy turret = GetComponent<TurrentEnemy>().rightLeftcheck();
    }

    void Update()
    {
        bulletDir();
    }

    private void bulletDir()
    {
        if (bulletDirCheck == false)
        {
            transform.position += transform.right * bulletSpeed * Time.deltaTime;
        }
        else if (bulletDirCheck == true)
        {
            transform.position += -transform.right * bulletSpeed * Time.deltaTime;
        }
    }

}
