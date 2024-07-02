using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{

    [Header("이동 및 점프")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] bool GroundCheck;
    
    Vector3 moveDir;
    float verticalvelocity;//0

    bool ground;

    Animator anim;
    Rigidbody2D rigid;
    CapsuleCollider2D capColl;
    BoxCollider2D box2coll;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        capColl = GetComponent<CapsuleCollider2D>();
        box2coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        move();
        
        anime();
    }

    private void move()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        moveDir.y = rigid.velocity.y;
        rigid.velocity = moveDir;
    }

    private void anime()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
    }

    
}
