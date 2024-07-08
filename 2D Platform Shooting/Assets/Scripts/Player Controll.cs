using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [Header("�÷��̾� ü��")]
    [SerializeField, Range(1, 10)] float maxHp;
    [SerializeField] float curHp;

    [Header("�÷��̾� �̵� �� ����")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] int jumpCount;
    [SerializeField] bool jumping;

    [Header("Ground üũ")]
    [SerializeField] bool showGroundCheck;
    [SerializeField] float showGroundLengh;
    [SerializeField] Color showGroundColor;
    [SerializeField] bool isGround;

    Camera cam;
    Vector3 moveDir;
    Rigidbody2D rigid;
    CapsuleCollider2D cap2coll;
    BoxCollider2D box2coll;
    Animator anim;

    private void OnDrawGizmos()//Gizmos üũ�� �뵵
    {
        if (showGroundCheck == true)
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, showGroundLengh), showGroundColor);
            //�� ��ġ, ����ġ - ShowGroundLengh, Color
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cap2coll = GetComponent<CapsuleCollider2D>();
        box2coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        anims();
    }

    private void anims()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        //anim.SetBool("IsGround", isGround);
    }
}
