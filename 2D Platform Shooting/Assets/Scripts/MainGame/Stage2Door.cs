using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();

        if (collision.tag == "Player")
        {
            GameObject stage2 = GameObject.Find("Stage2Door");
            player.transform.position = stage2.transform.position;
        }
        //위의 방향처럼 진행하면 여러 스크립트를 생성하는 문제가생김
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
