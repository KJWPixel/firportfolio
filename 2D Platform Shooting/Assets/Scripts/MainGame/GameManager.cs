using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ��ŸƮ, ����, Ʃ�丮��, ����")]
    [SerializeField] TMP_Text startGame;
    [SerializeField] TMP_Text gameOver;
    [SerializeField] Image tutorialText;
    [SerializeField] float tutorialTextTime = 5f;
    float tutorialTextTimer = 0f;

    [Header("Ʃ�丮�� �޴��� ��ư")]
    [SerializeField] Image tutorialsMenual;
    [SerializeField] bool tutorialMenualOn;

    bool startGameArhpa; //���� ���۽� ���ӽ��� ������ �� �ƿ��� ���� bool��
    bool gameOverArhpa;  //���� ������ ���ӿ��� ������ �� �ƿ��� ���� bool��
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

    private void startText()//���ӽ��� �� �ؽ�Ʈ ���
    {
        Color color = startGame.color;
        startGame.color = color;
        
        if (startGameArhpa == false)
        {
            color.a += Time.deltaTime;
            if (color.a >= 1.0f)//Time.deltaTime�� ��Ȯ�� 1�� ������ �� ���� 1.0���� ũ�ų� ���������� ��ȣ�� ����
            {
                color.a = 1.0f;
                startGameArhpa = true;
            }
            startGame.color = color;
        }     

        if (startGameArhpa == true)
        {
            color.a -= Time.deltaTime;
            if (color.a <= 0.0f)//color.a���� 0�� �Ǹ� ��Ȱ��ȭ
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
            if(tutorialTextTimer > tutorialTextTime)//Tiemr > Tiem���� Ŭ �� Text fasle
            {
                tutorialText.gameObject.SetActive(false);
            }      
        }   
    }

    private void tutorialsButton()
    {

    }

    private void gameOvertext()//���ӿ��� �� �ؽ�Ʈ ���
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
