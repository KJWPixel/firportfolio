using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
    [SerializeField] bool isJump;
    [SerializeField] bool twoJump;

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
            //�� ��ġ, ����ġ - ShowGroundLengh, Color
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
        rigid.velocity = moveDir;//������ٵ�2D�� Vector�� moveDir ����
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
        RaycastHit2D hit = Physics2D.BoxCast(box2Coll.bounds.center, box2Coll.bounds.size, 0f, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));//�������� ������ �� ����
        //Physics2D.Raycast(transform.position, Vector2.down, ShowGroundLengh, LayerMask.GetMask("Ground"));

        if (hit)
        {
            isGround = true;
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

}
