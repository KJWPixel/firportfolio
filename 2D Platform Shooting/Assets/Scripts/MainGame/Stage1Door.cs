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
        //위의 방향처럼 진행하면 여러 스크립트를 생성하는 문제가생김
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
