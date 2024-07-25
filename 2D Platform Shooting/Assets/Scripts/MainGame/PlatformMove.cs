using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Header("�÷��� �ӵ�")]
    [SerializeField] float platformSpeed;

    //[Header("�÷��� ���� uncheck:���� check:����")]
    //[SerializeField] bool changeDir;

    [Header("�÷��� Ư����ġ����")]
    [SerializeField] Transform trsLocationStart;
    [SerializeField] Transform trsLocationEnd;
    Transform trsRepetition;

    Rigidbody2D rigid;
    BoxCollider2D box2coll;
    Vector3 platformDir;


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    PlayerControll player = collision.GetComponent<PlayerControll>();
    //    if (collision.tag == "Player")
    //    {
    //        playerCheck = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    PlayerControll player = collision.GetComponent<PlayerControll>();
    //    if(collision.tag == "Player")
    //    {
    //        playerCheck = false;
    //    }
    //}
    void Start()
    {
        transform.position = trsLocationStart.position;
        platformDir = transform.position;
        trsRepetition = trsLocationEnd;
    }

    void Update()
    {
        platformMove();
        //platformRepetition();
    }

    private void platformMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, trsLocationEnd.position, platformSpeed * Time.deltaTime);
    }

    private void platformRepetition()
    {
        if(trsRepetition == trsLocationEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, trsLocationStart.position, platformSpeed * Time.deltaTime);
        }
    }
}
