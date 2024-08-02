using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        btnExit.onClick.AddListener(exitWindowbtnNo);
        btnExit.onClick.AddListener(exitWindowbtnYes);
    }

    private void init()
    {
        ExitWindow.SetActive(false);

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void gameStart()
    {
        //게임시작 메인게임으로 이동
        SceneManager.LoadScene(1);
    }

    private void gameExit()
    {
        //게임종료 시 종료확인창 활성화
        if(exitWindowOn == false)
        {
            ExitWindow.SetActive(true);
            exitWindowOn = true;
        }
    }

    private void exitWindowbtnNo()
    {
        //종료확인창에 아니요를 누를 시 종료확인창 비활성화
        if(exitWindowOn == true)
        {
            ExitWindow.SetActive(false);
            exitWindowOn = false;       
        }     
    }

    private void exitWindowbtnYes() 
    {
        //종료확인창에 예를 누를 시 게임종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
