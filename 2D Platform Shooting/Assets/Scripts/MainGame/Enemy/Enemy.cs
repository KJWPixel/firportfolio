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

    //private void OnTriggerEnter2D(Collider2D collision)//해당 Trigger PlayerControll에서 해결됨
    //{
    //    //if (collision.tag == "Player")//플레이어에 닿았을 경우 적의 damage가 player의 Hit매개변수에 들어가 플레이어의 hp를 감소시킴
    //    //{
    //    //    PlayerControll player = collision.GetComponent<PlayerControll>();//collision으로 인한 Error 해결완료
    //    //    player.Hit(damage);
    //    //}
    //    //아래 HitBox.enumHitBoxType.Body:에서 실행되므로 주석처리 
    //}

    private void OnDrawGizmos()//Gizmos 체크의 용도
    {
        if (showChaseCheck == true)
        {
            //Debug.DrawLine(transform.position, transform.position - new Vector3(0, chaseDistance), chaseDistanceColor);
            //내 위치, 내위치 - ShowGroundLengh, Color
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

                if (other.tag == "Player")//플레이어에 닿았을 경우 적의 damage가 player의 Hit매개변수에 들어가 플레이어의 hp를 감소시킴
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
            playerDir.Normalize();//피타고라스 x,y직선거리좌표에서 그 사이 값에 따른 속도를 x,y축과 같게 만듬
            transform.position += playerDir * moveSpeed * Time.deltaTime;
            //Start에서 GameObject.Find에서 Player의 Transform컴포넌트를 가져옴

            //Vector3 playerDir = Player.position - transform.position; 
            //transform.position += playerDir * moveSpeed * Time.deltaTime;
            //둘다 동일한 동작

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
