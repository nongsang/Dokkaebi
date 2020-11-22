﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraCtrl3 : MonoBehaviour
{
    private Transform tr = null;
    public GameObject player = null;
    public GameObject mainCamera = null;

    public float mouseX = 0.0f;
    public float mouseY = 0.0f;

    public float xSensitivity = 2.0f;
    public float ySensitivity = 2.0f;

    public float rotateX = 0.0f;
    public float rotateY = 0.0f;

    public float maxXAngle = 80.0f;
    public float minXAngle = -45.0f;

    public Vector2 mouseMoveDir = Vector2.zero;

    public float minDistance = 1.0f;    // 카메라의 최소 거리
    public float maxDistance = 4.0f;    // 카메라의 최대 거리
    public float offsetDistance = 1.8f; // 카메라의 거리를 보정하는 변수
    public float followSpeed = 20.0f;   // 카메라의 위치를 잡는 속도
    public float currDistance = 0.0f;   // 카메라와 대상의 현재 거리

    public Vector3 dollyDir = Vector3.zero; // 카메라가 있는 방향
    public Vector3 desCamPos = Vector3.zero;// 카메라를 옮길 위치

    private void Start()
    {
        tr = GetComponent<Transform>();

        // 부모 오브젝트에서 카메라 지점까지 상대방향을 구한다.
        dollyDir = mainCamera.transform.localPosition.normalized;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotateY += mouseX * xSensitivity;
        rotateX -= mouseY * ySensitivity;

        rotateX = Mathf.Clamp(rotateX, minXAngle, maxXAngle);

        mouseMoveDir = (rotateY * Vector2.up) + (rotateX * Vector2.right);

        // 마우스의 움직임에 따라 회전
        Quaternion newRot = Quaternion.Euler(mouseMoveDir);
        tr.rotation = newRot;
    }

    private void LateUpdate()
    {
        // 카메라는 플레이어를 따라다닌다.
        tr.position = player.transform.position + Vector3.up * offsetDistance;

        Vector3 lookPoint = player.transform.position + Vector3.up * offsetDistance;

        // 카메라는 어느 한 지점을 본다.
        mainCamera.transform.LookAt(lookPoint);
    }

    private void FixedUpdate()
    {
        desCamPos = tr.TransformPoint(dollyDir * currDistance);

        RaycastHit hit;

        if (Physics.Raycast(tr.position, -tr.forward, out hit, maxDistance))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                currDistance = Mathf.Clamp(hit.distance - offsetDistance, minDistance, maxDistance);
            }
        }
        else
        {
            currDistance = maxDistance;
        }

        mainCamera.transform.position = desCamPos;
    }
}
