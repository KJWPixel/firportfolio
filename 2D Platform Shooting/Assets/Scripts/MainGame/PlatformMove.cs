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

    //collsion�ȿ� ������ �ڽ����� ���ӽ�Ű�� �����÷����� �÷��̾ �����ϰ� �̵���
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
