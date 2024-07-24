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
        //���� ����ó�� �����ϸ� ���� ��ũ��Ʈ�� �����ϴ� ����������
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
                if (color.a >= 1.0f)//Time.deltaTime�� ��Ȯ�� 1�� ������ �� ���� 1.0���� ũ�ų� ���������� ��ȣ�� ����
                {
                    color.a = 1.0f;
                    stage2Text = true;
                }
                stageStartText.color = color;
            }

            if (stage2Text == true)
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
