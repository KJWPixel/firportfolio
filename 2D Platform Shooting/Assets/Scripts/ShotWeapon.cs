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
        //ī�޶� ��������Ʈ���� ���콺 �Ÿ�
        Vector2 showDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //���콺 �Ÿ��� ���� ���� ���
        //Mathf.Atan2 = y, x���� ������ Radian��(float��)  * Mathf.Rad2Deg�� ���ϸ� Degree��(����)
        float angle = Mathf.Atan2(showDir.y, showDir.x) * Mathf.Rad2Deg;

        //������ ���� ����� ������ ȸ����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                //�Ѿ� ����
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward), dynamicObject);
                //������ �Ѿ� ������ 
                shotTimer = shotTime + Time.time;
            }
        }
    }
}
