using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    //[SerializeField] GameObject[] swapWeapon;//리스트로 교체할 무기 선택
    [SerializeField] GameObject swapWeapon1;
    [SerializeField] GameObject swapWeapon2;
    [SerializeField] GameObject swapWeapon3;

    bool sawp1;
    bool sawp2;
    bool sawp3;

    void Start()
    {

    }

    void Update()
    {
        changeWeapon();
    }

    public void changeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            swapWeapon1.SetActive(true);
            swapWeapon2.SetActive(false);
            swapWeapon3.SetActive(false);
            //bool sawp1 = true;
            //bool sawp2 = false;
            //bool sawp3 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            swapWeapon1.SetActive(false);
            swapWeapon2.SetActive(true);
            swapWeapon3.SetActive(false);
            //bool sawp1 = false;
            //bool sawp2 = true;
            //bool sawp3 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            swapWeapon1.SetActive(false);
            swapWeapon2.SetActive(false);
            swapWeapon3.SetActive(true);
            //bool sawp1 = false;
            //bool sawp2 = false;
            //bool sawp3 = false;
        }
    }
}
