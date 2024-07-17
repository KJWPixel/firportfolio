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
        if(collision.tag == "Enemy")//�Ѿ��� ������ ������ �Ѿ��� �����ǰ� �ش� �� Hit�Լ� �Ű������� bulletDamage�� �� �ش��� hp�� ���ҽ�Ŵ
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
