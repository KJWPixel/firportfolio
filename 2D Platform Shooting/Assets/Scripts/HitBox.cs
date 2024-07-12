using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public enum enumHitBoxType
    {
        Body,
        Chase,
    }

    Enemy enemy;
    [SerializeField] enumHitBoxType hitBoxType;

    void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemy.TriggerEnter(collision, hitBoxType);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.TriggerExit(collision, hitBoxType);
    }
}
