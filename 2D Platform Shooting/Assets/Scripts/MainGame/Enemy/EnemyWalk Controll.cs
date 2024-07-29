using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkControll : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int turnMove;

    Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Invoke("turn", 3);
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        groundCheck();
        move();     
        anims();
        turnAnim();
    }

    private void move()
    {
        rigid.velocity = new Vector2(turnMove * moveSpeed, rigid.velocity.y);
    }

    private void turn()
    {
        turnMove = Random.Range(-1, 2);//랜덤값의 Range의 경우 -1~1까지됨
        Invoke("turn", 3);//3초후 다시 재실행
    }

    private void groundCheck()
    {
        //ray로 Ground체크하여 턴
        Vector2 check = new Vector2(rigid.position.x + turnMove, rigid.position.y);
        Debug.DrawRay(check, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(check, Vector3.down, 1, LayerMask.GetMask("Ground"));
        if(rayHit.collider == null)
        {
            turnMove *= -1;
            CancelInvoke();
            Invoke("turn", 1);
        }
    }

    private void anims()
    {
        anim.SetInteger("Horizontal", turnMove);
    }

    private void turnAnim()
    {
        Vector3 scale = transform.localScale;
        if (turnMove == 1)
        {
            scale.x = -1;
            transform.localScale = scale;
        }
        if (turnMove == -1)
        {
            scale.x = 1;
            transform.localScale = scale;
        }
    }
}
