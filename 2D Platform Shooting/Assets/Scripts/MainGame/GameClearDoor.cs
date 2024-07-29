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
        //위의 방향처럼 진행하면 여러 스크립트를 생성하는 문제가생김
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
                if (color.a >= 1.0f)//Time.deltaTime은 정확히 1로 떨어질 수 없어 1.0보다 크거나 같으면으로 부호를 변경
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
                //if (color.a <= 0.0f)//color.a값이 0이 되면 비활성화
                //{
                //    gameClearText.gameObject.SetActive(false);
                //}
                //gameClearText.color = color;

                //SceneManager.LoadScene(0);
            }

        }
    }
}
