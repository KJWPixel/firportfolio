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
        Vector2 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);//ī�޶� ����, ���콺��ǥ
        //if(Input.GetMouseButtonDown(0))//���߾��� x0, y0
        //{
        //    Debug.Log(mouseWorldPos);
        //}
        Vector2 playerPos = transform.position;
        Vector2 fixedPos = mouseWorldPos - playerPos;
        //if (Input.GetMouseButtonDown(0))//�÷��̾� Ŭ���� x0, y0 �ٸ� ��ġ Ŭ���� �ش� �Ÿ� ��ǥ 
        //{
        //    Debug.Log(fixedPos);
        //}

        float angle = Quaternion.FromToRotation(transform.localScale.x < 0 ? Vector3.right : Vector3.left, fixedPos).eulerAngles.z;//?
        hand.rotation = Quaternion.Euler(0, 0, angle); //rotation = Quaternion�� EulerRotation�� ����
    }
}
