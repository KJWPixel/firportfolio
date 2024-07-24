using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stage2Door : MonoBehaviour
{
    [SerializeField] TMP_Text stageStartText;

    bool stage2Text;
    bool stage2Start;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();

        if (collision.tag == "Player")
        {
            GameObject stage2 = GameObject.Find("Stage2Door");
            player.transform.position = stage2.transform.position;
            stage2Start = true;
        }
        //위의 방향처럼 진행하면 여러 스크립트를 생성하는 문제가생김
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Stage2StartText();
    }

    private void Stage2StartText()
    {
        Color color = stageStartText.color;
        stageStartText.color = color;

        if (stage2Start == true)
        {
            if (stage2Text == false)
            {
                color.a += Time.deltaTime;
                if (color.a >= 1.0f)//Time.deltaTime은 정확히 1로 떨어질 수 없어 1.0보다 크거나 같으면으로 부호를 변경
                {
                    color.a = 1.0f;
                    stage2Text = true;
                }
                stageStartText.color = color;
            }

            if (stage2Text == true)
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
