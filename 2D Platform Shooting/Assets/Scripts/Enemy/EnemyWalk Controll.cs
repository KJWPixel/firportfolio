using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkControll : MonoBehaviour
{
    [SerializeField] int turnMove;

    Rigidbody rigid;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void move()
    {
        rigid.velocity = new Vector2(turnMove, rigid.velocity.y);
    }

    private void turn()
    {
        turnMove = Random.Range(-1, 2);//·£´ý°ªÀÇ RangeÀÇ °æ¿ì -1~1±îÁöµÊ
        Invoke("turn", 5);
    }

    private void anims()
    {
        //anim.SetInteger("Horizontal", turnMove);
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
