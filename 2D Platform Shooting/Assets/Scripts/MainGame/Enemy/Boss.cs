using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float damage;
    [SerializeField] public bool bossSpawn;

    Rigidbody2D rigid;
    BoxCollider2D box2coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerControll player = collision.GetComponent<PlayerControll>();
            if(player.curHp >= 10)
            {
                player.Hit(damage);
            }           
            if(player.curHp <= 10)
            {
                player.curHp = 1;
            }
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box2coll = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        init();
    }

    private void init()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        bossMove();
    } 

    private void bossMove()
    {
        rigid.velocity = new Vector2(1 * moveSpeed, rigid.velocity.y);
    }
}
