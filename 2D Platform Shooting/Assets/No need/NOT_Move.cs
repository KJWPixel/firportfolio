using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    //manager, 비동기적으로 호출이 왔을때에만 대응
    //controller, updata사용 동기적으로 호출이 오지 않더라도 타 기능을 불러서 사용하는 경우가 많음
    [Header("플레이어 이동 및 점프")]
    Rigidbody2D rigid;//null
    CapsuleCollider2D coll;
    BoxCollider2D box2d;
    Animator anim;//null
    Vector3 moveDir;//0, 0, 0
    float verticalVelocity = 0f;//수직으로 떨어지는 힘

    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    [SerializeField] bool showGroundCheck;
    [SerializeField] float groundCheckLength;//이 길이가 게임에서 얼마만큼의 길이로 나오는지 육안으로 보기전까지는 알 수가 없음

    [SerializeField] Color colorGroundCheck;

    [SerializeField] bool isGround;//인스펙터에서 플레이어가 플랫폼타일에 착지 했는지
    bool isJump;
    bool twoJump;

    Camera camMain;

    [Header("벽 점프")]
    [SerializeField] bool touchWall;
    bool isWallJump;
    [SerializeField] float wallJumpTime = 0.3f;
    float wallJumpTimer = 0.0f;//타이머

    [Header("대시")]
    [SerializeField] private float dashTime = 0.3f;
    [SerializeField] private float dashSpeed = 20.0f;
    float dashTimer = 0.0f;//타이머
    TrailRenderer dashEffect;//null
    [SerializeField] private float dashCoolTime = 2f;
    float dashCoolTimer = 0.0f;//타이머



    private void OnDrawGizmos()//체크의 용도
    {
        ///gameObject.SetActive(false);

        if (showGroundCheck == true)
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, groundCheckLength), colorGroundCheck);

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

    //private void OnTriggerEnter2D(Collider2D collision)//상대방의 콜라이더를 가져옴, 누가 실행시킨지는 모름
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //    {
    //        touchWall = true;
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Wall")) 
    //    {
    //        touchWall = false;
    //    }
    //}

    //public void TriggerEnter(HitBox.ehitboxType _type, Collider2D _collision)
    //{
    //    if (_type == HitBox.ehitboxType.WallCheck)
    //    {
    //        if (_collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //        {
    //            touchWall = true;
    //        }
    //    }
    //}

    //public void TriggerExit(HitBox.ehitboxType _type, Collider2D _collision)
    //{
    //    if (_type == HitBox.ehitboxType.WallCheck)
    //    {
    //        if (_collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
    //        {
    //            touchWall = false;
    //        }
    //    }
    //}

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        box2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        dashEffect = GetComponent<TrailRenderer>();
        dashEffect.enabled = false;
        
    }

    void Start()
    {
        camMain = Camera.main;
    }
    void Update()
    {

        
        checkGround();

        dash();

        moving();
        
        jump();
        doubleJump();

        chedkGravity();

        doAnim();
    }

    private void dash()
    {
        if (dashTimer == 0.0f && dashCoolTimer == 0.0f && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.F)))
        {
            //Input.GetKeyDown(DashKey);
            dashTimer = dashTime;
            dashCoolTimer = dashCoolTime;
            verticalVelocity = 0;
            dashEffect.enabled = true;
            //if (transform.localScale.x > 0)//왼쪽
            //{
            //    rigid.velocity = new Vector2(-dashSpeed, verticalVelocity);
            //}
            //else//오른쪽
            //{
            //    rigid.velocity = new Vector2(dashSpeed, verticalVelocity);
            //}             

            //rigid.velocity = transform.localScale.x > 0 ? new Vector2(-dashSpeed, verticalVelocity) : new Vector2(dashSpeed, verticalVelocity); 삼중다항식

            rigid.velocity = new Vector2(transform.localScale.x > 0 ? -dashSpeed : dashSpeed, 0.0f); //Vector2안에서 삼중다항식
        }
    }


    private void checkGround()
    {
        isGround = false;

        if (verticalVelocity > 0f)
        {
            return;
        }

        //float.PositiveInfinity //포지티브, 네거티브(반대방향) 무한으로 발사 
        //Layer int로 대상의 레이어를 구분
        //Layer의 int와 공통적으로 활용하는 int와 다름
        //Wall Layer, Ground Layer
        RaycastHit2D hit =
        //Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, LayerMask.GetMask("Ground")); //최초 위치로 부터(origin), 방향(direction), Vector2.donw == new vcetor(0, -1)

        Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, groundCheckLength, LayerMask.GetMask("Ground"));

        if (hit)//Raycast Ray가 닿았다면 true
        {
            isGround = true;
        }
    }

    private void moving()
    {
        if (wallJumpTimer > 0.0f || dashTimer > 0.0f)
        {
            return;
        }
        //좌우키를 누르면 좌우로 움직인다
        moveDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;//a, Left Key -1, d, Right Key 1, 아무것도 입력하지 않으면 0 
        moveDir.y = rigid.velocity.y;
        //슈팅게임 만들는 오브젝트를 코드에 의해서 순간이동 하게 만들었지만 이번에는 물리에 의해서 이동     
        rigid.velocity = moveDir;//y 0 Time.deltaTime
    }

  

    private void jump()
    {      

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            isJump = true;

        }
        twoJump = false;
    }

    private void chedkGravity()
    {
        if (dashTimer > 0.0f)
        {
            return;
        }
        else if (isWallJump == true)
        {
            isWallJump = false;

            Vector2 dir = rigid.velocity;
            dir.x *= -1f;//반대방향
            rigid.velocity = dir;

            verticalVelocity = jumpForce * 0.5f;
            //일정시간 유저가 입력할 수 없어야 벽을 발로찬 x값을 볼 수 있음
            //입력불가 타이머를 작동시켜야함
            wallJumpTimer = wallJumpTime;
        }
        else if (isGround == false)//공중에 떠있는 상태
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; //-9.81 

            if (verticalVelocity < -10f) //중력 -10이하로 내려갈 수 없음
            {
                verticalVelocity = -10f;
            }
        }
        else if (isJump == true)
        {
            isJump = false;
            verticalVelocity = jumpForce;
        }
        else if (isGround == true)
        {
            verticalVelocity = 0;
        }

        rigid.velocity = new Vector2(rigid.velocity.x, verticalVelocity);
    }

    private void doAnim()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);


    }
    private void doubleJump()
    {
        if (isGround == false && isJump == false && twoJump == false && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
            twoJump = true;
        }
    }

}
