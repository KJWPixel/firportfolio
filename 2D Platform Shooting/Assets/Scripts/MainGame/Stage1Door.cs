using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();

        if (collision.tag == "Player")
        {
            GameObject stage1 = GameObject.Find("Stage1Door");
            player.transform.position = stage1.transform.position;
        }
        //���� ����ó�� �����ϸ� ���� ��ũ��Ʈ�� �����ϴ� ����������
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
