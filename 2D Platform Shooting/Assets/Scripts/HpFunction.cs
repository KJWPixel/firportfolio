using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        imgaeHp.fillAmount = 1;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetHp(float _maxHp, float _curHp)//0~1
    {
        imgaeHp.fillAmount = _curHp / _maxHp;
    }
}
