using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpFunction : MonoBehaviour
{
    [SerializeField] Image imgaeHp;
    
    PlayerControll playerControll;


    private void Awake()
    {
        initHp();
    }

    private void initHp()
    {
        imgaeHp.fillAmount = 1f;
    }
    void Start()
    {
        playerControll = PlayerControll.Instance;
        imgaeHp.fillAmount = playerControll.curHp / playerControll.maxHp;
    }

    void Update()
    {
        //imgaeHp.fillAmount = 0.5f;//fillAmount Test
        //hpText.text = imgaeHp.fillAmount.ToString();
        currentHp();
    }
    public void SetHp(float _curHp, float _maxHp)
    {
        imgaeHp.fillAmount = _curHp / _maxHp;
    }

    private void currentHp()
    {
        imgaeHp.fillAmount = playerControll.curHp / playerControll.maxHp;
    }
}
