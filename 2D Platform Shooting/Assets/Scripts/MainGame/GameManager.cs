using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("���� ��ŸƮ, ����")]
    [SerializeField] TMP_Text startGame;
    [SerializeField] TMP_Text gameOver;

    [Header("���� �Ѿ�")]
    [SerializeField] Image restBullet;

    bool startGameArhpa; //���� ���۽� ���ӽ��� ������ �� �ƿ��� ���� bool��
    bool gameOverArhpa;  //���� ������ ���ӿ��� ������ �� �ƿ��� ���� bool��

    public GameObject Sniper;
    public GameObject ShotGun;

    PlayerControll playerControll;
    WeaponManager weaponManager;
    ShotWeapon shotWeapon;

    void Start()
    {
        initText();
        playerControll = PlayerControll.Instance;
        weaponManager.GetComponent<WeaponManager>();
    }

    void Update()
    {
        startText();
        gameOvertext();
        restFillAmount();
    }

    private void initText()
    {
        Color startColor = startGame.color;
        startColor.a = 0f;
        Color overColor = gameOver.color;
        overColor.a = 0f;
        restBullet.fillAmount = 1f;
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

    public void restFillAmount()
    {
        if (weaponManager.sawp1 == true) 
        {
            ShotWeapon shotWeapon = GetComponent<ShotWeapon>();
            restBullet.fillAmount = shotWeapon.bulletCounting / shotWeapon.bulletCount;
        }
    }
}
