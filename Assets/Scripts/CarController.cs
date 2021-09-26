using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Camera camera;

    private Rigidbody rb;
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float TurnSpeed;

    private float CurrentSpeed=1;
    private float MaxSpeed=60;
    private Vector3 Moving;

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
    void LateUpdate()
    {
        CameraControl();
    }
    private void Move()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            CurrentSpeed += MoveSpeed * Input.GetAxis("Vertical");
        }
        else
        {
            if (Input.GetAxis("Vertical") == 0 && CurrentSpeed>0)
            {
                CurrentSpeed -= MoveSpeed;
            }
        }
        Moving = transform.forward * CurrentSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + Moving);
    }
    private void Turn()
    {
        Quaternion turn = Quaternion.Euler(0f, TurnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation*turn);
        
    }
    private void CameraControl()
    {
        camera.gameObject.transform.rotation = Quaternion.Euler(60f, -60f, 0f);
        camera.gameObject.transform.position = new Vector3(transform.position.x + 12f, transform.position.y + 26f, transform.position.z - 7.5f);
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 && camera.orthographicSize < (5 + Mathf.Abs(Input.GetAxis("Vertical")) * 5))
        {
            camera.orthographicSize += 0.01f;
        }
        else
        {
            if(camera.orthographicSize>5)
            {
                camera.orthographicSize -= 0.01f;
            }
        }
    }
}
