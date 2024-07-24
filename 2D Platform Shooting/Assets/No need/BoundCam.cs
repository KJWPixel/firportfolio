using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCam : MonoBehaviour
{
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (trsPlayer == null) return;
        //Mathf.Clamp(trsPlayer.position.x, curBound.min.x, curBound.max.x),
        //Mathf.Clamp(trsPlayer.position.y, curBound.min.y, curBound.max.y),
        //mainCam.transform.position.z
            
    }

    private void checkBound()
    {
        float height = mainCam.orthographicSize;
        float width = height * mainCam.aspect;// aspect => width / height

        //curBound = coll.bounds;

        //float minX = curBound.min.x + width;
        //float minY = curBound.max.y + height;

        //curBound.SetMinMax(new Vector3(minX,minY)), new Vector3(maxX,maxY)
    }
}
