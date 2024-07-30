using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShotWeapon : MonoBehaviour
{
    [Header("�Ѿ� �� �� �߻���ġ")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] public int bulletCount;
    [SerializeField] public int bulletCounting;

    [Header("�߻� �� ������ �ð�")]
    [SerializeField] float shotDelayTime;
    float shotDelayTimer;

    [Header("������ �ð�")]
    [SerializeField] float reloadTime;
    float reloadTimer;
    [SerializeField] Image reloadeImage;

    [SerializeField] Transform dynamicObject;



    void Start()
    {
        initBulletCount();
        
    }

    void Update()
    {
        reload();
        Shot();
        imagefillAmount();

    }

    private void initBulletCount()
    {
        bulletCounting = bulletCount;
        
    }
    private void Shot()
    {
        //ī�޶� ��������Ʈ���� ���콺 �Ÿ�
        Vector2 showDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //���콺 �Ÿ��� ���� ���� ���
        //Mathf.Atan2 = y, x���� ������ Radian��(float��)  * Mathf.Rad2Deg�� ���ϸ� Degree��(����)
        float angle = Mathf.Atan2(showDir.y, showDir.x) * Mathf.Rad2Deg;

        //������ ���� ����� ������ ȸ����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        shotDelayTimer += Time.deltaTime;
        if (Input.GetMouseButton(0)) //���콺Ŭ�� �߻�
        {
            if (shotDelayTimer > shotDelayTime && bulletCounting > 0)//ShotDelay ����
            {
                //�Ѿ� ����                                                  //�ޱ� ���� 
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward), dynamicObject);
                bulletCounting--;

                shotDelayTimer = 0;
            }
        }
    }

    private void reload()
    {     
        if (bulletCounting <= 0)//bulletCount�� 0���ϰ� �Ǹ� Reload����
        {
            bulletCounting = 0;
            reloadTimer += Time.deltaTime;
            
            if (reloadTimer >= reloadTime)
            {          
                bulletCounting = bulletCount;
                reloadTimer = 0;
            }
        }
    }

    private void imagefillAmount()
    {      
        reloadeImage.fillAmount =  (float)bulletCounting / (float)bulletCount;
        if(bulletCounting == 0)
        {
            reloadeImage.fillAmount = reloadTimer / reloadTime;
        }
    }

    
}
