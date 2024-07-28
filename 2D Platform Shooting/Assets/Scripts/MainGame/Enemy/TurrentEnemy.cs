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

    [Header("uncheck시 right check시 left")]
    [SerializeField] public bool rightLeftcheck;

    //[SerializeField] bool showRayCheck;
    //[SerializeField] float showRayLengh;
    //[SerializeField] Color showRayColor;

    BoxCollider2D box2coll;

    //private void OnDrawGizmos()
    //{
    //    if(showRayCheck == true)//turret이 Ray를 쏴 거리를 RaycastHit로 player를 감지하면 true가 되며 총알을 발사함
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
            //Quaternion.identity와 Quaternion.AngleAxis는 동일하게 bullet에 적용
            shotTimer = 0;
        }
        
        //if (shotTimer > shotTime && playerCheck == true )
        //{
        //    Instantiate(enemyBullet, spawnPoint, )

        //}
    }

}
