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
        //���� ����ó�� �����ϸ� ���� ��ũ��Ʈ�� �����ϴ� ����������
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
                if (color.a >= 1.0f)//Time.deltaTime�� ��Ȯ�� 1�� ������ �� ���� 1.0���� ũ�ų� ���������� ��ȣ�� ����
                {
                    color.a = 1.0f;
                    stage1Text = true;
                }
                stageStartText.color = color;
            }

            if(stage1Text == true)
            {
                color.a -= Time.deltaTime;
                if (color.a <= 0.0f)//color.a���� 0�� �Ǹ� ��Ȱ��ȭ
                {
                    stageStartText.gameObject.SetActive(false);
                }
                stageStartText.color = color;
            }
        }
    }
}
