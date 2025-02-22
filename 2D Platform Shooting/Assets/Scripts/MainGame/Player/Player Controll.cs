using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControll : MonoBehaviour
{
    public static PlayerControll Instance;//null Awake에서 Instance지정
    [Header("플레이어 체력")]
    [SerializeField] public float maxHp;
    [SerializeField] public float curHp;

    [Header("플레이어 이동 및 점프")]
    [SerializeField] float moveSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] int doublejumpCount;
    int doublejumpCounting;
    [SerializeField] bool jumping;

    [Header("플레이어 무적 시간")]
    [SerializeField] bool invincibilty;
    [SerializeField] float invincibiltyTime;//무적시간   
    float invincibiltyTimer;

    [Header("Ground 체크")]
    [SerializeField] bool showGroundCheck;
    [SerializeField] float showGroundLengh;
    [SerializeField] Color showGroundColor;
    [SerializeField] bool isGround;
    float verticalVelocity;
    public bool playerDie = false;
 
    Camera cam;
    Vector3 moveDir;
    Rigidbody2D rigid;
    CapsuleCollider2D cap2coll;
    BoxCollider2D box2coll;
    Animator anim;
    SpriteRenderer spriteRenderer;

    private void OnDrawGizmos()//Gizmos 체크의 용도
    {
        if (showGroundCheck == true)
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(0, showGroundLengh), showGroundColor);
            //내 위치, 내위치 - ShowGroundLengh, Color
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        cap2coll = GetComponent<CapsuleCollider2D>();
        box2coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Instance == null)//Instance가 null이면 Instance를 채워줌
        {
            Instance = this;
        }
        else//Instance가 이미 존재한다면 Destroy
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        cam = Camera.main;
    }


    void Update()
    {
        checkGround();
        curHpLimit();
        moving();
        jump();
        doublejump();
        reverseAim();

        checkGravity();
        invincibiltyCheck();
        anims();
    }

    private void anims()
    {
        anim.SetInteger("Horizontal", (int)moveDir.x);
        anim.SetBool("IsGround", isGround);
    }

    private void moving()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDir.y = rigid.velocity.y;
        rigid.velocity = moveDir;//리지드바디2D에 Vector값 moveDir 대입
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //rigid.AddForce(Vector2.up * jumpForce);            
            jumping = true;
        }
    }

    private void doublejump()
    {
        if (jumping == true && Input.GetKeyDown(KeyCode.Space) && isGround == false && doublejumpCounting > 0)
        {
            verticalVelocity = 0;
            verticalVelocity += jumpForce;
            doublejumpCounting--;
        }
    }

    private void checkGround()
    {
        isGround = false;

        if (verticalVelocity > 0f)
        {
            return;
        }
        //BoxCast box2coll 콜라이더에서, box2coll사이즈, angle은 0, y축은 -1, 길이: showGroundLengh, 레이어가 Ground면 Hit
        RaycastHit2D hit = Physics2D.BoxCast(box2coll.bounds.center, box2coll.bounds.size, 0f, Vector2.down, showGroundLengh, LayerMask.GetMask("Ground"));
        //Physics2D.Raycast(transform.position, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));

        if (hit)
        {
            isGround = true;
            jumping = false;
            doublejumpCounting = doublejumpCount;
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
        else if (jumping == true)
        {
            verticalVelocity = jumpForce;
        }
        else if (isGround == true)
        {
            verticalVelocity = 0;
        }
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

    public void Hit(float _damage)
    {
        if(invincibilty == true || playerDie == true)//무적이 true 또는 playerDie가 true면 리턴
        {
            return;
        }

        //if (playerDie == true)
        //{
        //    return;
        //}

        curHp -= _damage;

        invincibilty = true;

        if (curHp <= 0)
        {
            playerDie = true;
        }
    }

    private void invincibiltyCheck()
    {
        //Player 몹에 닿을 시 Hit함수에서 데미지를 입고, invincibilty = true면 
        //invincibiltyCheck함수에서 invincibilty == true를 감지하고 invincibiltyTime시간에 맞쳐 Timer가 동작하는 동안 Sprite의 Color.a값이 0.5f
        //invincibiltyTime이 끝이 나면 Sprite의 Color.a값을 1f로 되돌림
        Color color = spriteRenderer.color;

        if (invincibilty == true)
        {       
            color.a = 0.5f;
            invincibiltyTimer += Time.deltaTime;
        }

        if (invincibiltyTimer > invincibiltyTime)
        {
            color.a = 1f;
            invincibiltyTimer = 0f;
            invincibilty = false;
        }
        spriteRenderer.color = color;
    }

    private void curHpLimit()
    {
        if(curHp >= maxHp)
        {
            curHp = maxHp;
        }
    }

    
}
