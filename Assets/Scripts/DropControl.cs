using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropControl : MonoBehaviour
{
    Vector3 gameStartPos = new Vector3(0, 28, -3);

    const float jumpAcc = -15;
    float JumpV = 0;
    float deltaDis;
    float jumpDis = 0;
    float jumpHeight = 2;

    //float fallStartLocation = 28;
    float fallTime = 0.632455532f;
    float fallEndV = -6.32455532f;

    const int STATUS_JUMP = 0;
    const int STATUS_FALL = 1;
    int moveStatus = 0;

    // Use this for initialization
    void Start()
    {
        transform.position = gameStartPos;
        fallTime = Mathf.Sqrt(jumpHeight * 2 / -jumpAcc);
        fallEndV = jumpAcc * fallTime;
    }

    // Update is called once per frame
    void Update()
    {
        switch(moveStatus)
        {
            case STATUS_JUMP:
                deltaDis = (float)(JumpV * Time.deltaTime + jumpAcc * 0.5 * Time.deltaTime * Time.deltaTime);
                transform.localPosition += new Vector3(0, deltaDis, 0);
                JumpV += jumpAcc * Time.deltaTime; //v = v0 + at
                break;

            case STATUS_FALL:
                deltaDis = JumpV * Time.deltaTime;
                transform.localPosition += new Vector3(0, deltaDis, 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #if UNITY_EDITOR
        Debug.Log("OnTriggerEnter");
        #endif
        moveStatus = STATUS_FALL;
        GameControl.falling = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("PassStage"))
        {
            #if UNITY_EDITOR
            Debug.Log("Bingo!");
            #endif
        }
        Debug.Log("OnCollisionEnter");
        
        moveStatus = STATUS_JUMP;
        JumpV = -fallEndV;
        GameControl.falling = false;
    }

    void Jump(bool drop = false)
    {
        float deltaDis = (float)(JumpV * Time.deltaTime + jumpAcc * 0.5 * Time.deltaTime * Time.deltaTime);
        jumpDis += Mathf.Abs(deltaDis);
        transform.position += new Vector3(0, deltaDis, 0);
        if (jumpDis >= jumpHeight)
        {
            var pos = transform.position;
            //transform.position = new Vector3(pos.x, )
            jumpDis = 0;
            JumpV = -JumpV;
        }
        else
            JumpV += jumpAcc * Time.deltaTime;
    }
}
