using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button btnStart;
    [SerializeField] Button btnExit;

    private void Awake()
    {
        btnStart.onClick.AddListener(gameStart);
        btnExit.onClick.AddListener(gameExit);  
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
        SceneManager.LoadScene(1);
    }

    private void gameExit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
