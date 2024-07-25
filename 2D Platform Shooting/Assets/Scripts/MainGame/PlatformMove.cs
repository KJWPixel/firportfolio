using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [Header("ÇÃ·§Æû ¼Óµµ")]
    [SerializeField] float platformSpeed;

    //[Header("ÇÃ·§Æû ¹æÇâ uncheck:¼¼·Î check:°¡·Î")]
    //[SerializeField] bool changeDir;

    [Header("ÇÃ·§Æû Æ¯Á¤À§Ä¡±îÁö")]
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
