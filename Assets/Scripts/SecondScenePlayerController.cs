using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScenePlayerController : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hMove, 0f, vMove);
        move.Normalize();
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
