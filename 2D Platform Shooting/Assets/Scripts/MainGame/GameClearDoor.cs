using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearDoor : MonoBehaviour
{
    [SerializeField] TMP_Text gameClearText;

    bool gameClearCheck;
    bool gameText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControll player = collision.GetComponent<PlayerControll>();
        if (collision.tag == "Player")
        {
            gameClearCheck = true;
        }
        //���� ����ó�� �����ϸ� ���� ��ũ��Ʈ�� �����ϴ� ����������
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClearText();
    }

    private void ClearText()
    {
        Color color = gameClearText.color;
        gameClearText.color = color;

        if (gameClearCheck == true)
        {
            if (gameText == false)
            {
                color.a += Time.deltaTime;
                if (color.a >= 1.0f)//Time.deltaTime�� ��Ȯ�� 1�� ������ �� ���� 1.0���� ũ�ų� ���������� ��ȣ�� ����
                {
                    color.a = 1.0f;
                    gameText = true;
                }
                gameClearText.color = color;               
            }

            if (gameText == true)
            {
                SceneManager.LoadScene(0);
                //color.a -= Time.deltaTime;
                //if (color.a <= 0.0f)//color.a���� 0�� �Ǹ� ��Ȱ��ȭ
                //{
                //    gameClearText.gameObject.SetActive(false);
                //}
                //gameClearText.color = color;

                //SceneManager.LoadScene(0);
            }

        }
    }
}
