using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] float verticalVelocityMove;//
    Rigidbody2D rigid;
    BoxCollider2D box2coll;
    Vector2 moveDir;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();
        if (collision.tag == "Player")
        {
            moveDir.y = verticalVelocityMove;
        }
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
