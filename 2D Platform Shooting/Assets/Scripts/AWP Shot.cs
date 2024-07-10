using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AWPShot : MonoBehaviour
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
        awpShot();
    }

    private void awpShot()
    {
        //ī�޶� ��������Ʈ���� ���콺 �Ÿ�
        Vector2 showDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //���콺 �Ÿ��� ���� ���� ���
        float angle = Mathf.Atan2(showDir.y, showDir.x) * Mathf.Rad2Deg;
        //������ ���� ����� ������ ȸ����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = rotation;

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
