using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float heal;

    CapsuleCollider2D cap2coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            PlayerControll palyer = collision.GetComponent<PlayerControll>();
            palyer.hp += heal;
        }
    }
    private void Awake()
    {
        cap2coll = GetComponent<CapsuleCollider2D>();
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
