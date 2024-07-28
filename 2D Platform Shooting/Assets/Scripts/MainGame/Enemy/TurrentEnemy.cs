using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class TurrentEnemy : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform dynamicObject;
    [SerializeField] float shotTime;
    float shotTimer;

    [SerializeField] bool autoShot;

    [Header("uncheck�� right check�� left")]
    [SerializeField] public bool rightLeftcheck;

    //[SerializeField] bool showRayCheck;
    //[SerializeField] float showRayLengh;
    //[SerializeField] Color showRayColor;

    BoxCollider2D box2coll;

    //private void OnDrawGizmos()
    //{
    //    if(showRayCheck == true)//turret�� Ray�� �� �Ÿ��� RaycastHit�� player�� �����ϸ� true�� �Ǹ� �Ѿ��� �߻���
    //    {
    //        Debug.DrawLine(transform.position, transform.position - new Vector3(showRayLengh, 0), showRayColor);
    //    }
    //}

    void Start()
    {
        
    }

    void Update()
    {
        shot();
    }

    private void shot()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > shotTime &&  autoShot == true)
        {
            Instantiate(enemyBullet, spawnPoint.position, Quaternion.identity, dynamicObject);
            //Instantiate(enemyBullet, spawnPoint.position, Quaternion.AngleAxis(0, Vector3.forward), dynamicObject);
            //Quaternion.identity�� Quaternion.AngleAxis�� �����ϰ� bullet�� ����
            shotTimer = 0;
        }
        
        //if (shotTimer > shotTime && playerCheck == true )
        //{
        //    Instantiate(enemyBullet, spawnPoint, )

        //}
    }

}
