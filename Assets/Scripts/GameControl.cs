using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject mainScene;
    public GameObject mainBall;

    bool touched;
    Vector3 touchPos;
    Vector3 lastPos;

    public static bool falling = false;
    int heightOffset = 4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Physics.gravity = Vector3.zero;
            touched = true;
            #if UNITY_EDITOR
            Debug.Log("touched = true");
            #endif
            lastPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Physics.gravity = new Vector3(0, -9.8f, 0);
            touched = false;
            #if UNITY_EDITOR
            Debug.Log("touched = false");
            #endif
        }

        if(touched)
        {
            touchPos = Input.mousePosition;
            var dis = Vector3.Distance(touchPos, lastPos) / 2;
            if (touchPos.x < lastPos.x)
                dis = -dis;
            //Debug.Log(dis);
            mainScene.transform.Rotate(0, -dis, 0);
            lastPos = touchPos;
        }

        if(falling)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                mainBall.transform.localPosition.y + heightOffset,
                transform.localPosition.z);
        }
        
    }

    void MoveCamera()
    {

    }
    
}
