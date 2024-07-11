using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] float bulletDemage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);    
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Hit(bulletDemage);
        }
    }
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    
    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
}
