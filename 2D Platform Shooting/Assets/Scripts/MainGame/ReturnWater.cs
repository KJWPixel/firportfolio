using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnWater : MonoBehaviour
{
    [SerializeField] GameObject returnObj;
    [SerializeField] float returnDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();
        if(collision.tag == "Player")
        {
            player.transform.position = returnObj.transform.position;
            player.Hit(returnDamage);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
