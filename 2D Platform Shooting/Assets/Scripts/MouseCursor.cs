using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseC : MonoBehaviour
{
    [Header("커서 이미지")]
    [SerializeField, Tooltip("0,은 <color=red>디폴트</color>, 1은 <color=red>클릭</color>")] List<Texture2D> cursor;
    Texture2D[] cursors;


}
