using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControll : MonoBehaviour
{

    [Header("�̵� �� ����")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;

    [SerializeField] Color ShowGroundColor;
    [SerializeField] float ShowGroundLengh;
    [SerializeField] bool ShowGroundCheck;

    float verticalVelocity = 0.0f; //�������� �ӵ�
    [SerializeField]  bool isGround;//�׶���üũ
    [SerializeField] bool isJump;//����üũ

    Vector3 moveDir;
    Camera cam;

    Animator anim;
    Rigidbody2D rigid;
    CapsuleCollider2D cap2Coll;
    BoxCollider2D box2Coll;

    
    private void OnDrawGizmos()//üũ�� �뵵
    {       
        if (ShowGroundCheck == true)
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, ShowGroundLengh), ShowGroundColor);
          
            //float sphereRange = 5; Gizmos �׽�Ʈ
            //Vector3 cubeSize = new Vector3(3, 10, 7);
            //Gizmos.color = colorGroundCheck;
            //Gizmos.DrawWireSphere(transform.position, sphereRange);
            //Gizmos.DrawWireCube(transform.position, cubeSize);
        }
        //Debug.DrawLine(); ����׵� üũ�뵵�� �� ī�޶� ���� �׷��� �� ����
        //Gizmos.DrawSphere(); ����׺��� �� ���� �ð�ȿ���� ����
        //Handles.DrawWireArc
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        cap2Coll = GetComponent<CapsuleCollider2D>();
        box2Coll = GetComponent<BoxCollider2D>();
        cam = Camera.main;
    }

    void Start()
    {

    }

    void Update()
    {
        checkGround();
        checkGravity();       
        moving();
        jump();

        anims();
    }
    private void anims()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        anim.SetBool("IsGround", isGround);
    }

    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        moveDir.y = rigid.velocity.y;
        rigid.velocity = moveDir;//������ٵ�2D�� Vector�� moveDir ����
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJump = true;
        }                 
    }

    private void checkGround()
    {
        isGround = false;

        if(verticalVelocity > 0f)
        {
            return;
        }

        RaycastHit2D hit = //Physics2D.BoxCast(box2Coll.bounds.center, box2Coll.bounds.size, 0f, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));//�������� ������ �� ����
        Physics2D.Raycast(transform.position, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));

        if (hit)
        {
            isGround = true;
        }
    }

    private void checkGravity()
    {
        if (isGround == true)
        {
            return;
        }
        else if (isGround == false)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; //-9.81 

            if (verticalVelocity < -10f)
            {
                verticalVelocity = -10f;
            }
        }      
        else if (isJump == true)
        {
            isJump = false;
            verticalVelocity = JumpForce;
        }
        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
    }

    private void reverAnim()
    {
        Vector2 mouseworldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseworldPos - mouseworldPos;
    }

}
