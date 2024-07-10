using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
    [SerializeField] bool isJump;
    [SerializeField] bool twoJump;

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
            //내 위치, 내위치 - ShowGroundLengh, Color
        }
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
            
        moving();
        reverseAim();
        jump();
        doubleJump();

        checkGravity();
        anims();
    }
    private void anims()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        //anim.SetBool("IsGround", isGround);
    }

    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        moveDir.y = rigid.velocity.y;
        rigid.velocity = moveDir;//리지드바디2D에 Vector값 moveDir 대입
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJump = true;
        }
        twoJump = false;
    }

    private void doubleJump()
    {
        if (isGround == false && isJump == false && twoJump == false && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = JumpForce;
            twoJump = true;
        }
    }

    private void checkGround()
    {
        isGround = false;

        if(verticalVelocity > 0f)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.BoxCast(box2Coll.bounds.center, box2Coll.bounds.size, 0f, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));//아직까지 이해할 수 없음
        //Physics2D.Raycast(transform.position, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));

        if (hit)
        {
            isGround = true;
        }
    }

    private void checkGravity()
    {
        if (isGround == false)//공중에 떠있는 상태
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; //-9.81 

            if (verticalVelocity < -10f) //중력 -10이하로 내려갈 수 없음
            {
                verticalVelocity = -10f;
            }
        }
        else if (isJump == true)
        {          
            verticalVelocity = JumpForce;
        }
        else if (isGround == true)
        {
            verticalVelocity = 0;
        }
        isJump = false;
        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
        
    }

    private void reverseAim()
    {
        //방향키에 따른 플레이어 애니메이션 방향
        //Vector3 scale = transform.localScale;
        //if (moveDir.x < 0 && scale.x != 1.0f)//왼쪽
        //{
        //    scale.x = 1.0f;
        //    transform.localScale = scale;
        //    Debug.Log("<color=blue>동작</color>");
        //}
        //else if (moveDir.x > 0 && scale.x != -1.0f)//오른쪽 
        //{
        //    scale.x = -1.0f;
        //    transform.localScale = scale;
        //    Debug.Log("<color=rad>동작</color>");
        //}      

        //마우스커서에 따른 플레이어 애니메이션 방향
        //WorldPoint로 하지 않을 시 캔버스 기준으로 좌표를 찍음
        //WorldPoint의 경우 정중앙이 x 0 y 0으로 찍힘
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;

        Vector3 plalyerScale = transform.localScale;
        if (fixedPos.x > 0 && plalyerScale.x != -1.0f)
        {
            plalyerScale.x = -1.0f;
        }
        else if (fixedPos.x < 0 && plalyerScale.x != 1.0f)
        {
            plalyerScale.x = 1.0f;
        }
        transform.localScale = plalyerScale;

    }

}
