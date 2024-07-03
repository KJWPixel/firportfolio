using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{

    [Header("이동 및 점프")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;
    float verticalVelocity = 0f;

    [SerializeField] bool showGroundCheck;
    [SerializeField] float showGroundCheckLengh;
    [SerializeField] Color showGroundCheckColor;


    bool ground;
    Vector3 moveDir;

    Animator anim;
    Rigidbody2D rigid;
    CapsuleCollider2D cap2Coll;
    BoxCollider2D box2Coll;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (box2Coll != null)
        {
            verticalVelocity += Physics.gravity.y + Time.deltaTime;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        cap2Coll = GetComponent<CapsuleCollider2D>();
        box2Coll = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        moving();
        
        anims();
    }

    private void moving()
    {      
        moveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        moveDir.y = rigid.velocity.y;
        rigid.velocity = moveDir;//리지드바디2D에 Vector값 moveDir 대입
        

    }

    private void anims()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
    }

    
 }



