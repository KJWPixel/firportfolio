using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AWPShot : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotTime;

    float shotTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        awpShot();
    }

    private void awpShot()
    {
        //카메라 월드포인트에서 마우스 거리
        Vector2 showDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //마우스 거리로 부터 각도 계산
        float angle = Mathf.Atan2(showDir.y, showDir.x) * Mathf.Rad2Deg;
        //축으로 부터 방향과 각도의 회전값
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = rotation;

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                //총알 생성
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
                //재장전 총알 딜레이 
                shotTimer = shotTime + Time.time;
            }
        }
    }

    private void shot()
    {
       
        
    }


}
