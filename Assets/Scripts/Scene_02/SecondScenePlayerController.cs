using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScenePlayerController : MonoBehaviour
{
    private float _moveSpeed = 3f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    { 
        float _hMove = Input.GetAxis("Horizontal");
        float _vMove = Input.GetAxis("Vertical");
        Vector3 _move = new Vector3(_hMove, 0f, _vMove);
        _move.Normalize();
        _rb.MovePosition(_rb.position + _move * _moveSpeed * Time.deltaTime);
    }
}
