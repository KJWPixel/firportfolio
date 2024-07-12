using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWeapon : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotDelayTime;
    [SerializeField] Transform dynamicObject;

    float shotDelayTimer;

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

        shotDelayTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) //���콺Ŭ�� �߻�
        { 
            if (shotDelayTimer > shotDelayTime)//ShotDelay �ش� ���� �̱���
            {
                //�Ѿ� ����                                                  //�ޱ� ���� 
                Instantiate(bullet, spawnPoint.position, Quaternion.AngleAxis(angle - 90, Vector3.forward), dynamicObject);
                shotDelayTimer = 0;
            }
        }
    }
}
