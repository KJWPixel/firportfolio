using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControll : MonoBehaviour
{
    [SerializeField] Transform hand;
    [SerializeField] GameObject weapon;
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform bulletSpawnPoint;
    //[SerializeField] float shotTime;
    //[SerializeField] GameObject dynamicObject;

    Camera cam;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        checkAim();
    }

    private void checkAim()
    {
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);//카메라가 지도, 마우스좌표
        //if(Input.GetMouseButtonDown(0))//정중앙이 x0, y0
        //{
        //    Debug.Log(mouseWorldPos);
        //}
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;
        //if (Input.GetMouseButtonDown(0))//플레이어 클릭시 x0, y0 다른 위치 클릭시 해당 거리 좌표 
        //{
        //    Debug.Log(fixedPos);
        //}

        float angle = Quaternion.FromToRotation(transform.localScale.x < 0 ? Vector3.right : Vector3.left, fixedPos).eulerAngles.z;//?
        hand.rotation = Quaternion.Euler(0, 0, angle); //rotation = Quaternion을 EulerRotation로 변경
    }
}
