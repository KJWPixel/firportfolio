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

    Rigidbody2D rigid;
    CapsuleCollider2D cap2coll;

    Vector3 enemyDir;
    HitBox Hitbox;
    private void OnTriggerEnter2D(Collider2D collision)//해당 Trigger PlayerControll에서 해결됨
    {
        //if (collision.tag == "Player")//플레이어에 닿았을 경우 적의 damage가 player의 Hit매개변수에 들어가 플레이어의 hp를 감소시킴
        //{
        //    PlayerControll player = collision.GetComponent<PlayerControll>();//collision으로 인한 Error 해결완료
        //    player.Hit(damage);
        //}
        //아래 HitBox.enumHitBoxType.Body:에서 실행되므로 주석처리 
    }

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

    void Start()
    {
        cap2coll = GetComponent<CapsuleCollider2D>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        Hitbox = GetComponent<HitBox>();
    }

    // Update is called once per frame
    void Update()
    {
        //chasePlayerCheck();
        playerTracking();
    }

    //private void chasePlayerCheck()
    //{
    //    RaycastHit2D playerHit = Physics2D.CircleCast(cap2coll.bounds.center, 3f, new Vector2(3,3));

    //    if(playerHit)
    //    {
    //        chasePlayer = true;
    //    }
    //}

    private void playerTracking()
    {
        if (chasePlayer == true)
        {
            Vector3 playerDir = Player.transform.position - transform.position;
            transform.position += playerDir * moveSpeed *    Time.deltaTime;
            //Start에서 GameObject.Find에서 Player의 Transform컴포넌트를 가져옴

            //Vector3 playerDir = Player.position - transform.position; 
            //transform.position += playerDir * moveSpeed * Time.deltaTime;
            //둘다 동일한 동작
        }
    }

    public void Hit(float _damage)
    {
        if(enemyDie == true)
        {
            return;
        }

        hp -= _damage;

        if(hp <= 0 )
        {
            enemyDie = true;
            Destroy(gameObject);           
       }    
    }

    public void TriggerEnter(Collider2D other, HitBox.enumHitBoxType _type)
    {
        switch (_type)
        {
            case HitBox.enumHitBoxType.Body://0

                if (other.tag == "Player")//플레이어에 닿았을 경우 적의 damage가 player의 Hit매개변수에 들어가 플레이어의 hp를 감소시킴
                {
                    PlayerControll player = other.GetComponent<PlayerControll>();
                    player.Hit(damage);
                }
                break;

            case HitBox.enumHitBoxType.Chase://1
                chasePlayer = true;
                break;
        }
    }

    public void TriggerStay(Collider2D other, HitBox.enumHitBoxType _type)
    {
        if (other.tag == "Player")
        {
            playerTracking();
        }            
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
}
