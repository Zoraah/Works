using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    private float _turnSpeed = 90f;         //Скорость поврота куба
    private float _moveSpeed = 2f;          //Скорость движения куба
    private bool _isRaycastShow = false;    //Параметр отображения луча
    private float _rayLength = 50f;         //Длина луча
    private LineRenderer _rayLine;          //Линия для отрисовки луча
    private Rigidbody _rigidbody;           //Физическое тело игрока
    private Vector3 _rayStart;              //Точка начала луча
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rayLine = GetComponent<LineRenderer>();
        _rayLine.enabled = false;           //Изначальное отключение рендера линии
        _rayLine.startWidth = 0.5f;
        _rayLine.endWidth = 0.5f;
    }
    private void Update()
    {
        Move();                             //Управление для игрока
        if(Input.GetKeyDown("f"))           //Переключатель отображения линии и создания луча
        {
            if (!_rayLine.enabled)
            {
                _rayLine.enabled = true;
                _isRaycastShow = true;
            }
            else
            {
                _rayLine.enabled = false;
                _isRaycastShow = false;
            }
        }
    }
    private void FixedUpdate()
    {
        _rayStart = transform.position;     //Стартовая позиция луча
        _rayLine.SetPosition(0, _rayStart); //Стартовая точка линии
        if (_isRaycastShow)
        {
            RaycastHit _hit;
            if (Physics.Raycast(_rayStart, transform.forward, out _hit, _rayLength))
            {
                _rayLine.SetPosition(1, _hit.point);
            }
            else
            {
                _rayLine.SetPosition(1, transform.forward * _rayLength);
            }
        }
    }
    private void Move()
    {
        float _hMove = Input.GetAxis("Horizontal");
        float _vMove = Input.GetAxis("Vertical");
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(new Vector3(0f,_turnSpeed,0f) * _hMove * Time.deltaTime));
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _moveSpeed * _vMove * Time.deltaTime);
    }

}
