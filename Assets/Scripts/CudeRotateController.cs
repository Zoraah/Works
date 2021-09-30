using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CudeRotateController : MonoBehaviour
{
    private float _rotatePerMinute;
    private float _count = 0;
    private float _rotatePerSecond;

    private Vector3 _currentEulerAngles;
    private Quaternion _currentRotation;

    private bool _minus = false; 

    private void Start()
    {
        _rotatePerSecond = _rotatePerMinute/60*360;
    }
    private void Update()
    {
        Debug.Log(Time.time);
        _currentEulerAngles += new Vector3(0f, 1f, 0f) * Time.deltaTime * _rotatePerSecond;
        _currentRotation.eulerAngles = _currentEulerAngles;
        transform.rotation = _currentRotation;
        if (!_minus && transform.rotation.y < 0f)
        {
            _minus = true;
        }
        if (_minus && transform.rotation.y > 0f)
        {
            _minus = false;
            _count += 2;
        }
    }
}
