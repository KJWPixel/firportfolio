using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("�޴�")]
    [SerializeField] Button btnMenu;
    [SerializeField] Image menuWindow;

    [Header("�޴� ���")]
    [SerializeField] Button btnMenual;
    [SerializeField] Image menualWindow;
    [SerializeField] Button btnMenualClese;
    [SerializeField] Button btnClose;
    [SerializeField] Button btnTitle;
    [SerializeField] Button btnExit;

    //ĵ���� Inspector�� SortOrder�� Sprite�� Order in Layer�� ����� ������� ���ڰ� ���� ���� �켱������ ����
    //AutoCanvas -1, UICanvas 0 


    private void Awake()
    {
        btnMenu.onClick.AddListener(menuButton);//�ΰ��� �޴� ��ư
        btnMenual.onClick.AddListener(menualButton);//�޴�â ���۹� ��ư
        btnMenualClese.onClick.AddListener(meualCloserButton);//���۹�â �ݱ� ��ư
        btnClose.onClick.AddListener(menuCloserButton);//�޴�â �ݱ� ��ư
        btnTitle.onClick.AddListener(titleButton);//Ÿ��Ʋ�� �̵��ϴ� ��ư
        btnExit.onClick.AddListener(gameExitButton);//�������� ��ư
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void menuButton()//�ΰ��� �»�� �޴���ư ���, Ŭ���� �޴�â ���
    {
        menuWindow.gameObject.SetActive(true);
    }

    private void menualButton()//�޴����â�� ���۹������� Ŭ���� ����â�� ���
    {
        menualWindow.gameObject.SetActive(true);
    }

    private void meualCloserButton()//���۹�����â�� �ݴ� ���
    {
        menualWindow.gameObject.SetActive(false);
    }
    
    private void menuCloserButton()//�޴�â�� �ݴ� ���
    {
        menuWindow.gameObject.SetActive(false);
    }

    private void titleButton()//Ÿ��Ʋ�� ����
    {
        SceneManager.LoadScene(0);
    }

    private void gameExitButton()//�޴�â���� ������ �����ϴ� ���
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
