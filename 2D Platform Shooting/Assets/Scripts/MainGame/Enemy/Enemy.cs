using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    [SerializeField] float moveSpeed;
    [SerializeField] public float damage;
    bool enemyDie = false;
    Transform Player;

    [SerializeField] bool chasePlayer;
    [SerializeField] bool showChaseCheck;
    [SerializeField] float chaseDistance;
    [SerializeField] Color chaseDistanceColor;
    [SerializeField] bool playerTrackingOn;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;

    Vector3 enemyDir;
    HitBox Hitbox;

    //private void OnTriggerEnter2D(Collider2D collision)//�ش� Trigger PlayerControll���� �ذ��
    //{
    //    //if (collision.tag == "Player")//�÷��̾ ����� ��� ���� damage�� player�� Hit�Ű������� �� �÷��̾��� hp�� ���ҽ�Ŵ
    //    //{
    //    //    PlayerControll player = collision.GetComponent<PlayerControll>();//collision���� ���� Error �ذ�Ϸ�
    //    //    player.Hit(damage);
    //    //}
    //    //�Ʒ� HitBox.enumHitBoxType.Body:���� ����ǹǷ� �ּ�ó�� 
    //}

    private void OnDrawGizmos()//Gizmos üũ�� �뵵
    {
        if (showChaseCheck == true)
        {
            //Debug.DrawLine(transform.position, transform.position - new Vector3(0, chaseDistance), chaseDistanceColor);
            //�� ��ġ, ����ġ - ShowGroundLengh, Color
            //float sphereRange = 5;
            //Vector3 cubeSize = new Vector3(3, 10, 7);
            Gizmos.color = chaseDistanceColor;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
            //Gizmos.DrawWireCube(transform.position, cubeSize);
        }
    }

    public void TriggerEnter(Collider2D other, HitBox.enumHitBoxType _type)
    {
        switch (_type)
        {
            case HitBox.enumHitBoxType.Body:

                if (other.tag == "Player")//�÷��̾ ����� ��� ���� damage�� player�� Hit�Ű������� �� �÷��̾��� hp�� ���ҽ�Ŵ
                {
                    PlayerControll player = other.GetComponent<PlayerControll>();
                    player.Hit(damage);
                }
                break;

            case HitBox.enumHitBoxType.Chase:
                chasePlayer = true;
                break;
        }
    }

    public void TriggerStay(Collider2D other, HitBox.enumHitBoxType _type)
    {
    }

    public void TriggerExit(Collider2D other, HitBox.enumHitBoxType _type)
    {
        switch (_type)
        {
            case HitBox.enumHitBoxType.Body:

                break;

            case HitBox.enumHitBoxType.Chase:
                chasePlayer = false;
                break;
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Hitbox = GetComponent<HitBox>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTracking();
        turnAnims();
    }

    public void Hit(float _damage)
    {
        if (enemyDie == true)
        {
            return;
        }

        hp -= _damage;

        if (hp <= 0)
        {
            enemyDie = true;
            Destroy(gameObject);
        }
    }

    private void playerTracking()
    {
        if(chasePlayer == true)
        {
            Vector3 playerDir = Player.transform.position - transform.position;
            playerDir.Normalize();//��Ÿ��� x,y�����Ÿ���ǥ���� �� ���� ���� ���� �ӵ��� x,y��� ���� ����
            transform.position += playerDir * moveSpeed * Time.deltaTime;
            //Start���� GameObject.Find���� Player�� Transform������Ʈ�� ������

            //Vector3 playerDir = Player.position - transform.position; 
            //transform.position += playerDir * moveSpeed * Time.deltaTime;
            //�Ѵ� ������ ����

            //if (Vector2.Distance(transform.position, target.position) > chaseDistance)
            //{
            //    transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //}
        }       
    }

    private void turnAnims()
    {
        Vector3 scale = transform.localScale;
        enemyDir.x = rigid.velocity.x;
        if (enemyDir.x > moveSpeed)
        {
            scale.x = -1;
            transform.localScale = scale;
        }
        if (enemyDir.x < moveSpeed)
        {
            scale.x = 1;
            transform.localScale = scale;
        }
    }
}
