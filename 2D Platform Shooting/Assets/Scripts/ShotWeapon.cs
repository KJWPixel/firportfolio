using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWeapon : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotTime;
    [SerializeField] Transform dynamicObject;

    float shotTimer;

    void Start()
    {

    }

    void Update()
    {
        Shot();
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
        

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                //총알 생성
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward), dynamicObject);
                //재장전 총알 딜레이 
                shotTimer = shotTime + Time.time;
            }
        }
    }
}
