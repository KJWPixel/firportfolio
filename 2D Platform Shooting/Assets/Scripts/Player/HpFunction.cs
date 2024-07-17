using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HpFunction : MonoBehaviour
{
    [SerializeField] Image imgaeHp;
    float _curHp;
    float _maxHp;

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
        
    }

    void Update()
    {
        //imgaeHp.fillAmount = 0.5f;//fillAmount Test
        //hpText.text = imgaeHp.fillAmount.ToString();
    }
    public void SetHp(float _curHp, float _maxHp)
    {
        imgaeHp.fillAmount = _curHp / _maxHp;
    }
}
