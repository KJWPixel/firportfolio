using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("게임 스타트, 오버, 튜토리얼, 설명")]
    [SerializeField] TMP_Text startGame;
    [SerializeField] TMP_Text gameOver;
    [SerializeField] Image tutorialText;
    [SerializeField] float tutorialTextTime = 5f;
    float tutorialTextTimer = 0f;

    [Header("튜토리얼 메뉴얼 버튼")]
    [SerializeField] Image tutorialsMenual;
    [SerializeField] bool tutorialMenualOn;

    bool startGameArhpa; //게임 시작시 게임시작 페이즈 인 아웃에 대한 bool값
    bool gameOverArhpa;  //게임 오버시 게임오버 페이즈 인 아웃에 대한 bool값
    bool tutorialArhpa;
    bool tutorialManual;

    PlayerControll playerControll;
    WeaponManager weaponManager;
    ShotWeapon shotWeapon;

    void Start()
    {
        initText();
        playerControll = PlayerControll.Instance;
    }

    void Update()
    {
        startText();  
        tutorials();   
        gameOvertext();
        //restFillAmount();
    }

    private void initText()
    {
        Color startColor = startGame.color;
        startColor.a = 0f;
        Color overColor = gameOver.color;
        overColor.a = 0f;
        //restBullet.fillAmount = 1f;
        //tutorialText.gameObject.SetActive(false);
        //tutorialsMenual.gameObject.SetActive(false);
    }

    private void startText()//게임시작 시 텍스트 출력
    {
        Color color = startGame.color;
        startGame.color = color;
        
        if (startGameArhpa == false)
        {
            color.a += Time.deltaTime;
            if (color.a >= 1.0f)//Time.deltaTime은 정확히 1로 떨어질 수 없어 1.0보다 크거나 같으면으로 부호를 변경
            {
                color.a = 1.0f;
                startGameArhpa = true;
            }
            startGame.color = color;
        }     

        if (startGameArhpa == true)
        {
            color.a -= Time.deltaTime;
            if (color.a <= 0.0f)//color.a값이 0이 되면 비활성화
            {
                startGame.gameObject.SetActive(false);
            }
            startGame.color = color;
        }
    }

    private void tutorials()
    {
        Color color = tutorialText.color;
        tutorialText.color = color;
        if (startGameArhpa == true)
        {        
            tutorialText.gameObject.SetActive(true);
            tutorialTextTimer += Time.deltaTime;
            if(tutorialTextTimer > tutorialTextTime)//Tiemr > Tiem보다 클 시 Text fasle
            {
                tutorialText.gameObject.SetActive(false);
            }      
        }   
    }

    private void tutorialsButton()
    {

    }

    private void gameOvertext()//게임오버 시 텍스트 출력
    {
        Color color = gameOver.color;
        gameOver.color = color;
        

        if (playerControll.playerDie == true)
        {
            if(gameOverArhpa == false)
            {
                color.a += Time.deltaTime;
                if(color.a >= 1.0f)
                {
                    color.a = 1.0f;
                    gameOverArhpa = true;   
                }
                gameOver.color = color;
            }

            if(gameOverArhpa == true)
            {
                color.a -= Time.deltaTime;
                if(color.a <= 0.0f)
                {
                    gameOver.gameObject.SetActive(false);
                    SceneManager.LoadScene(0);
                }
                gameOver.color = color;
            }
        } 
    }
}
