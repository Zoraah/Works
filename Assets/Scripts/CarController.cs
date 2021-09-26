using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float TurnSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
    }
    void Update()
    {
        
    }
    private void Move()
    {
        Vector3 move = transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        rb.MovePosition(rb.position+move);
    }
    private void Turn()
    {
        Quaternion turn = Quaternion.Euler(0f, TurnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation*turn);
    }
}
