using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float damage;
    BoxCollider2D box2coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerControll player = collision.GetComponent<PlayerControll>();
            player.Hit(damage);
        }
    }
    private void Awake()
    {
        box2coll = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
