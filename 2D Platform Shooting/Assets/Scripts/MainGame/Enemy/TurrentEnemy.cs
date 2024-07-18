using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentEnemy : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] bool playerCheck;
    [SerializeField] float shotTime;
    float shotTimer;

    [SerializeField] bool showRayCheck;
    [SerializeField] float showRayLengh;
    [SerializeField] Color showRayColor;

    BoxCollider2D box2coll;

    private void OnDrawGizmos()
    {
        if(showRayCheck == true)//turret�� Ray�� �� �Ÿ��� RaycastHit�� player�� �����ϸ� true�� �Ǹ� �Ѿ��� �߻���
        {
            Debug.DrawLine(transform.position, transform.position - new Vector3(showRayLengh, 0), showRayColor);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        checkPlayer();
        shot();
    }

    private void checkPlayer()
    {

    }

    private void shot()
    {
        shotTimer += Time.deltaTime;
        //if (shotTimer > shotTime && playerCheck == true )
        //{
        //    Instantiate(enemyBullet, spawnPoint, )

        //}
    }
}
