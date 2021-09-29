using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CudeRotateController : MonoBehaviour
{
    public float RPM;
    public float Count = 0;
    public float RotatePerSecond;

    Vector3 currentEulerAngles;
    Quaternion currentRotation;

    private bool minus = false; 

    void Start()
    {
        RotatePerSecond = RPM/60*360;
    }
    void Update()
    {
        Debug.Log(Time.time);
        currentEulerAngles += new Vector3(0f, 1f, 0f) * Time.deltaTime * RotatePerSecond;
        currentRotation.eulerAngles = currentEulerAngles;
        transform.rotation = currentRotation;
    }
    void FixedUpdate()
    {
        if(!minus && transform.rotation.y<0f)
        {
            minus = true;
        }
        if(minus && transform.rotation.y>0f)
        {
            minus = false;
            Count+=2;
        }
    }
}
