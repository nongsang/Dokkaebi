using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2 : MonoBehaviour
{
    private Rigidbody rb = null;

    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;

    public float currMoveSpeed = 10.0f;

    private Vector3 moveDir = Vector3.zero;

    private float mouseX = 0.0f;
    private float mouseY = 0.0f;

    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;

    public float rotateX = 0.0f;
    public float rotateY = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotateY += mouseX * xSensitivity;
        rotateX -= mouseY * ySensitivity;

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        moveDir = rb.transform.forward * verticalInput + rb.transform.right * horizontalInput;
    }

    private void FixedUpdate()
    {
        rb.transform.rotation = Quaternion.Euler(0.0f, rotateY, 0.0f);

        rb.MovePosition(rb.position + (moveDir.normalized * currMoveSpeed * Time.fixedDeltaTime));
    }
}
