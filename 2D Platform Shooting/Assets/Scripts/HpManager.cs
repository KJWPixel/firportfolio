using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [SerializeField] Image imgae;
    [SerializeField] Image imageEffect;

    [SerializeField, Range(0.1f, 10f)] float effectTime = 1;
    PlayerControll playerControll;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
