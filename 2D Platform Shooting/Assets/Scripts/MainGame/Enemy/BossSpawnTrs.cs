using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTrs : MonoBehaviour
{
    [SerializeField] GameObject boss;
    Rigidbody2D rigid;
    BoxCollider2D box2coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            boss.SetActive(true);
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box2coll = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
