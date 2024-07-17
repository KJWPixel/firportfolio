using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float lifeTime;
    [SerializeField] float bulletDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")//총알이 적에게 맞으면 총알은 삭제되고 해당 적 Hit함수 매개변수에 bulletDamage이 들어가 해당적 hp를 감소시킴
        {
            Destroy(gameObject);    
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            enemy.Hit(bulletDamage);
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
