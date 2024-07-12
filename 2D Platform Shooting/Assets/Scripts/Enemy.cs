using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    [SerializeField] float moveSpeed;
    [SerializeField] public float damage;
    bool enemyDie = false;

    [SerializeField] bool chasePlayer;
    [SerializeField] bool showChaseCheck;
    [SerializeField] float chaseDistance;
    [SerializeField] Color chaseDistanceColor;

    Rigidbody2D rigid;
    CapsuleCollider2D cap2coll;

    Vector3 enemyDir;

    private void OnTriggerEnter2D(Collider2D collision)//�ش� Trigger PlayerControll���� �ذ��
    {
        if (collision.tag == "Player")//�÷��̾ ����� ��� ���� damage�� player�� Hit�Ű������� �� �÷��̾��� hp�� ���ҽ�Ŵ
        {
            PlayerControll player = collision.GetComponent<PlayerControll>();//collision���� ���� Error �ذ�Ϸ�
            player.Hit(damage);
        }
    }

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

    void Start()
    {
        cap2coll = GetComponent<CapsuleCollider2D>();
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
            //PlayerControll player = transform.GetComponent<PlayerControll>();
          
            //rigid.velocity = enemyDir;
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
