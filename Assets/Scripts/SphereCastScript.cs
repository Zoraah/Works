using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCastScript : MonoBehaviour
{
    private float _turnSpeed = 90f;
    private float _moveSpeed = 4f;
    private Rigidbody _rigidbody;
    private float _sphereRadius = 0.3f;
    private float _maxDistance = 3f;
    private Vector3 _playerPosition;
    [SerializeField]
    private GameObject _hitObject;
    private float _distanceToObject;

    private void Move()
    {
        float _hMove = Input.GetAxis("Horizontal");
        float _vMove = Input.GetAxis("Vertical");
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(new Vector3(0f, _turnSpeed, 0f) * _hMove * Time.deltaTime));
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _moveSpeed * _vMove * Time.deltaTime);
    }
    private void ActiveSphereCast()
    {
        RaycastHit _hit;
        _playerPosition = transform.position;
        if (Physics.SphereCast(_playerPosition, _sphereRadius, transform.forward, out _hit, _maxDistance))
        {
            _hitObject = _hit.collider.gameObject;
            _distanceToObject = _hit.distance;
            _hit.rigidbody.AddForce(-_hit.normal * 20f);
        }
        else
        {
            _hitObject = null;
            _distanceToObject = _maxDistance;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.forward * _distanceToObject,_sphereRadius);
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        ActiveSphereCast();
    }
}
