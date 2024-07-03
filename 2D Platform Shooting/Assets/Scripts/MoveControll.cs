using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControll : MonoBehaviour
{

    [Header("이동 및 점프")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpForce;

    [SerializeField] Color ShowGroundColor;
    [SerializeField] float ShowGroundLengh;
    [SerializeField] bool ShowGroundCheck;

    float verticalVelocity = 0.0f; //떨어지는 속도
    [SerializeField]  bool isGround;//그라운드체크
    [SerializeField] bool isJump;//점프체크

    Vector3 moveDir;
    Camera cam;

    Animator anim;
    Rigidbody2D rigid;
    CapsuleCollider2D cap2Coll;
    BoxCollider2D box2Coll;

    
    private void OnDrawGizmos()//체크의 용도
    {       
        if (ShowGroundCheck == true)
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, ShowGroundLengh), ShowGroundColor);
          
            //float sphereRange = 5; Gizmos 테스트
            //Vector3 cubeSize = new Vector3(3, 10, 7);
            //Gizmos.color = colorGroundCheck;
            //Gizmos.DrawWireSphere(transform.position, sphereRange);
            //Gizmos.DrawWireCube(transform.position, cubeSize);
        }
        //Debug.DrawLine(); 디버그도 체크용도로 씬 카메라에 선을 그려줄 수 있음
        //Gizmos.DrawSphere(); 디버그보다 더 많은 시각효과를 제공
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
        rigid.velocity = moveDir;//리지드바디2D에 Vector값 moveDir 대입
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

        RaycastHit2D hit = //Physics2D.BoxCast(box2Coll.bounds.center, box2Coll.bounds.size, 0f, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));//아직까지 이해할 수 없음
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
