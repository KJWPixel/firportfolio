using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage1Door : MonoBehaviour
{
    [SerializeField] TMP_Text stageStartText;

    bool stage1Text;
    bool stage1Start;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();

        if (collision.tag == "Player")
        {
            GameObject stage1 = GameObject.Find("Stage1Door");
            player.transform.position = stage1.transform.position;
            stage1Start = true;
        }
        //위의 방향처럼 진행하면 여러 스크립트를 생성하는 문제가생김
    }
    void Start()
    {
        
    }

    void Update()
    {
        Stage1StartText();
    }

    private void Stage1StartText()
    {
        Color color = stageStartText.color;
        stageStartText.color = color;

        if (stage1Start == true)
        {
            if(stage1Text == false)
            {
                color.a += Time.deltaTime;
                if (color.a >= 1.0f)//Time.deltaTime은 정확히 1로 떨어질 수 없어 1.0보다 크거나 같으면으로 부호를 변경
                {
                    color.a = 1.0f;
                    stage1Text = true;
                }
                stageStartText.color = color;
            }

            if(stage1Text == true)
            {
                color.a -= Time.deltaTime;
                if (color.a <= 0.0f)//color.a값이 0이 되면 비활성화
                {
                    stageStartText.gameObject.SetActive(false);
                }
                stageStartText.color = color;
            }
        }
    }
}
