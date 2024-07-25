using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControll : MonoBehaviour
{
    public static PlayerControll Instance;//null Awake���� Instance����
    [Header("�÷��̾� ü��")]
    [SerializeField] public float maxHp;
    [SerializeField] public float curHp;

    [Header("�÷��̾� �̵� �� ����")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] int doublejumpCount;
    int doublejumpCounting;
    [SerializeField] bool jumping;

    [Header("�÷��̾� ���� �ð�")]
    [SerializeField] bool invincibilty;
    [SerializeField] float invincibiltyTime;//�����ð�   
    float invincibiltyTimer;

    [Header("Ground üũ")]
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
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Instance == null)//Instance�� null�̸� Instance�� ä����
        {
            Instance = this;
        }
        else//Instance�� �̹� �����Ѵٸ� Destroy
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
        rigid.velocity = moveDir;//������ٵ�2D�� Vector�� moveDir ����
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
        //BoxCast box2coll �ݶ��̴�����, box2coll������, angle�� 0, y���� -1, ����: showGroundLengh, ���̾ Ground�� Hit
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
        if (isGround == false)//���߿� ���ִ� ����
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; //-9.81 

            if (verticalVelocity < -10f) //�߷� -10���Ϸ� ������ �� ����
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
        //����Ű�� ���� �÷��̾� �ִϸ��̼� ����
        //Vector3 scale = transform.localScale;
        //if (moveDir.x < 0 && scale.x != 1.0f)//����
        //{
        //    scale.x = 1.0f;
        //    transform.localScale = scale;
        //    Debug.Log("<color=blue>����</color>");
        //}
        //else if (moveDir.x > 0 && scale.x != -1.0f)//������ 
        //{
        //    scale.x = -1.0f;
        //    transform.localScale = scale;
        //    Debug.Log("<color=rad>����</color>");
        //}      

        //���콺Ŀ���� ���� �÷��̾� �ִϸ��̼� ����
        //WorldPoint�� ���� ���� �� ĵ���� �������� ��ǥ�� ����
        //WorldPoint�� ��� ���߾��� x 0 y 0���� ����
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
        if(invincibilty == true || playerDie == true)//������ true �Ǵ� playerDie�� true�� ����
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
        //Player ���� ���� �� Hit�Լ����� �������� �԰�, invincibilty = true�� 
        //invincibiltyCheck�Լ����� invincibilty == true�� �����ϰ� invincibiltyTime�ð��� ���� Timer�� �����ϴ� ���� Sprite�� Color.a���� 0.5f
        //invincibiltyTime�� ���� ���� Sprite�� Color.a���� 1f�� �ǵ���
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
