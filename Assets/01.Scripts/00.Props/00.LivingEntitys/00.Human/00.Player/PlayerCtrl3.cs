using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCtrl3 : LivingEntity
{
    private Transform tr = null;
    private CharacterController cc = null;

    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;

    public float currMoveSpeed = 10.0f;
    public float currRotateSpeed = 45.0f;
    public float currJumpPower = 5.0f;
    public float currGravity = Physics.gravity.y;

    private Vector3 moveDir = Vector3.zero;
    private Quaternion rotateDir = Quaternion.identity;

    public float mouseX = 0.0f;
    public float mouseY = 0.0f;

    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;

    public float rotateX = 0.0f;
    public float rotateY = 0.0f;

    public float maxXAngle = 80.0f;
    public float minXAngle = -45.0f;

    public Vector2 mouseMoveDir = Vector2.zero;

    private void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MouseInput();
        CharacterMove();
    }

    void MouseInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotateY += mouseX * xSensitivity;
        rotateX -= mouseY * ySensitivity;

        rotateX = Mathf.Clamp(rotateX, minXAngle, maxXAngle);

        mouseMoveDir = (rotateY * Vector2.up) + (rotateX * Vector2.right);
    }

    private void CharacterMove()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // 이동방향 계산
        //moveDir = (verticalInput * tr.forward)
        // + (horizontalInput * tr.right);

        moveDir = (verticalInput * tr.forward)
         + (horizontalInput * tr.right);

        if (moveDir.sqrMagnitude != 0)
        {
            rotateDir = Quaternion.LookRotation(moveDir);
        }

        transform.rotation = rotateDir;

        cc.Move(moveDir.normalized * currMoveSpeed * Time.deltaTime);
    }
}
