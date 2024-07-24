using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("메뉴")]
    [SerializeField] Button btnMenu;
    [SerializeField] Image menuWindow;

    [Header("메뉴 목록")]
    [SerializeField] Button btnMenual;
    [SerializeField] Image menualWindow;
    [SerializeField] Button btnMenualClese;
    [SerializeField] Button btnClose;
    [SerializeField] Button btnTitle;
    [SerializeField] Button btnExit;

    //캔버스 Inspector의 SortOrder는 Sprite의 Order in Layer와 비슷한 기능을함 숫자가 높을 수록 우선순위를 가짐
    //AutoCanvas -1, UICanvas 0 


    private void Awake()
    {
        btnMenu.onClick.AddListener(menuButton);//인게임 메뉴 버튼
        btnMenual.onClick.AddListener(menualButton);//메뉴창 조작법 버튼
        btnMenualClese.onClick.AddListener(meualCloserButton);//조작법창 닫기 버튼
        btnClose.onClick.AddListener(menuCloserButton);//메뉴창 닫기 버튼
        btnTitle.onClick.AddListener(titleButton);//타이틀로 이동하는 버튼
        btnExit.onClick.AddListener(gameExitButton);//게임종료 버튼
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void menuButton()//인게임 좌상단 메뉴버튼 기능, 클릭시 메뉴창 띄움
    {
        menuWindow.gameObject.SetActive(true);
    }

    private void menualButton()//메뉴목록창에 조작법설명을 클릭시 설명창을 띄움
    {
        menualWindow.gameObject.SetActive(true);
    }

    private void meualCloserButton()//조작법설명창을 닫는 기능
    {
        menualWindow.gameObject.SetActive(false);
    }
    
    private void menuCloserButton()//메뉴창을 닫는 기능
    {
        menuWindow.gameObject.SetActive(false);
    }

    private void titleButton()//타이틀로 가기
    {
        SceneManager.LoadScene(0);
    }

    private void gameExitButton()//메뉴창에서 게임을 종료하는 기능
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
