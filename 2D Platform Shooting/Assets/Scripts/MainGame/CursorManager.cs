using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    //[Header("커서 이미지")]
    //[SerializeField, Tooltip("0,은 <color=red>디폴트</color>, 1은 <color=red>클릭</color>")] List<Texture2D> cursor; 

    [SerializeField] Image restBulletImage;
    //SerializeField] Texture2D image;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        

    }



    void Update()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        mouseWorldPos.x = (mouseWorldPos.x * Screen.width) - 50f;
        mouseWorldPos.y = (mouseWorldPos.y * Screen.height) - 50f;
        restBulletImage.transform.position = mouseWorldPos;

        //Vector2 mouseWorldPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //mouseWorldPos.x = (mouseWorldPos.x * Screen.width) - 50f;
        //mouseWorldPos.y = (mouseWorldPos.y * Screen.height) - 50f;
        //restBulletImage.transform.position = mouseWorldPos;

        //Cursor.SetCursor((Texture2D)restBulletImage, new Vector2(restBulletImage.transform.position.x, restBulletImage.transform.position.y), CursorMode.Auto);

        //if (Input.GetKey(KeyCode.Mouse0))//클릭을 했을때
        //{
        //    Cursor.SetCursor(cursor[1], new Vector2(cursor[1].width * 0.5f, cursor[1].height * 0.5f), CursorMode.Auto);
        //}
        //else
        //{
        //    Cursor.SetCursor(cursor[0], new Vector2(cursor[0].width * 0.5f, cursor[0].height * 0.5f), CursorMode.Auto);
        //}

        //ScreenToViewportPoint 왼쪽 하단 x:0, y0, 오른쪽 상단 x:1, y:1

    }
}
