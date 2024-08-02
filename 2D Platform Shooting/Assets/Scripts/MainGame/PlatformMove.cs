using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Header("플랫폼 속도")]
    [SerializeField] float platformSpeed;

    //[Header("플랫폼 방향 uncheck:세로 check:가로")]
    //[SerializeField] bool changeDir;

    [Header("플랫폼 특정위치까지")]
    [SerializeField] Transform trsLocationStart;
    [SerializeField] Transform trsLocationEnd;
    [SerializeField] bool trsRepetition;

    Rigidbody2D rigid;
    BoxCollider2D box2coll;
    Vector3 platformDir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.transform.SetParent(null);
        }
    }

    //collsion안에 있을때 자식으로 종속시키면 무브플랫폼와 플레이어가 동일하게 이동함
    void Start()
    {
        transform.position = trsLocationStart.position;
    }

    void Update()
    {
        platformMove();
    }

    private void platformMove()
    {
        if(trsRepetition == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, trsLocationEnd.position, platformSpeed * Time.deltaTime);
            if(transform.position == trsLocationEnd.position)
            {
                trsRepetition = true;
            }
        }
        else if(trsRepetition == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, trsLocationStart.position, platformSpeed * Time.deltaTime);
            if (transform.position == trsLocationStart.position)
            {
               trsRepetition = false;
            }
        }
    }
}
