using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    bool isDie = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerControll player = GetComponent<PlayerControll>();
            player.Hit(damage);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit(float _damage)
    {
        if(isDie == true)
        {
            return;
        }
        hp -= _damage;
        if(hp <= 0 )
        {
            isDie = true;
            Destroy(gameObject);           
       }    
    }
}
