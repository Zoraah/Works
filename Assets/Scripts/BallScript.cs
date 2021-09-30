using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _floor;
    [SerializeField]
    private int _passingCount=0;
    [SerializeField]
    private int _bouncingCount = 0;
    [SerializeField]
    private float _distanceToFloor = 0.0f;
    private LayerMask _counterLayerMask;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _counterLayerMask = 1 << 8;
        _counterLayerMask = ~_counterLayerMask;
        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        if(Physics.Raycast(downRay, out hit,Mathf.Infinity,_counterLayerMask))
        {
            _distanceToFloor = hit.distance;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Counter")
        {
            _passingCount++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        _bouncingCount++;
    }
}
