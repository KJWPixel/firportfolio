using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotWeapon : MonoBehaviour
{
    [Header("총알 수 및 발사위치")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] public int bulletCount;
    [SerializeField] public int bulletCounting;

    [Header("발사 후 딜레이 시간")]
    [SerializeField] float shotDelayTime;
    float shotDelayTimer;

    [Header("재장전 시간")]
    [SerializeField] float reloadTime;
    float reloadTimer;
    [SerializeField] Image reloadeCanvas;

    [SerializeField] Transform dynamicObject;



    void Start()
    {
        initBulletCount();
        
    }

    void Update()
    {
        Shot();
        reload();
    }

    private void initBulletCount()
    {
        bulletCounting = bulletCount;
        
    }
    private void Shot()
    {
        //카메라 월드포인트에서 마우스 거리
        Vector2 showDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //마우스 거리로 부터 각도 계산
        //Mathf.Atan2 = y, x값을 받으면 Radian값(float형)  * Mathf.Rad2Deg을 곱하면 Degree값(각도)
        float angle = Mathf.Atan2(showDir.y, showDir.x) * Mathf.Rad2Deg;

        //축으로 부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        shotDelayTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) //마우스클릭 발사
        {
            if (shotDelayTimer > shotDelayTime && bulletCounting > 0)//ShotDelay 구현
            {
                //총알 생성                                                  //앵글 각도 
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward), dynamicObject);
                bulletCounting--;
                reloadeCanvas.fillAmount = bulletCounting / bulletCount;
                shotDelayTimer = 0;               
            }
        }
    }

    private void reload()
    {
        if (bulletCounting <= 0)//bulletCount가 0이 되면 Reload Time동작
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer > reloadTime)
            {
                bulletCounting = bulletCount;
            }
        }
    }

    
}
