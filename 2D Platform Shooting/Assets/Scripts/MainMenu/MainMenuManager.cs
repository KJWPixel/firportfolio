using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button btnStart;
    [SerializeField] Button btnExit;
    [SerializeField] GameObject ExitWindow;
    [SerializeField] Button btnExitWindowNo;
    [SerializeField] Button btnExitWindowYes;

    bool exitWindowOn;
    

    private void Awake()
    {
        init();
        btnStart.onClick.AddListener(gameStart);
        btnExit.onClick.AddListener(gameExit);
        btnExitWindowNo.onClick.AddListener(exitWindowbtnNo);
        btnExitWindowYes.onClick.AddListener(exitWindowbtnYes);
    }

    private void init()
    {
        ExitWindow.SetActive(false);

    }

    void Start()
    {
    }

    private void gameStart()
    {
        //���ӽ��� ���ΰ������� �̵�
        if (exitWindowOn == false)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void gameExit()
    {
        //�������� �� ����Ȯ��â Ȱ��ȭ
        if(exitWindowOn == false)
        {
            ExitWindow.SetActive(true);
            exitWindowOn = true;
        }
    }

    private void exitWindowbtnNo()
    {
        //����Ȯ��â�� �ƴϿ並 ���� �� ����Ȯ��â ��Ȱ��ȭ
        if(exitWindowOn == true)
        {
            ExitWindow.SetActive(false);
            exitWindowOn = false;
        } 
    }

    private void exitWindowbtnYes() 
    {
        //����Ȯ��â�� ���� ���� �� ��������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
