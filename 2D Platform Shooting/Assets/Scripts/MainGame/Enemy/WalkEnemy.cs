using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkEnemy : MonoBehaviour
{
    [SerializeField] float maxHp;
    [SerializeField] float hp;
    [SerializeField] public float damage;
    [SerializeField] float moveSpeed;
    [SerializeField] int turnMove;
    bool enemyDie = false;

    Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Invoke("turn", 5);
    }

    void Start()
    {
        
    }

    
    void Update()
    {
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
        turnMove = Random.Range(-1, 2);//·£´ý°ªÀÇ RangeÀÇ °æ¿ì -1~1±îÁöµÊ
        Invoke("turn", 5);
    }

    private void anims()
    {
        anim.SetInteger("Horizontal", turnMove);
    }

    private void turnAnim()
    {
        Vector3 scale = transform.localScale;
        if (turnMove == 1 )
        {
            scale.x = -1;
            transform.localScale = scale;
        }
        if( turnMove == -1)
        {
            scale.x = 1;
            transform.localScale = scale;
        }
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
}
