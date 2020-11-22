using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseInput : MonoBehaviour
{
    [SerializeField] private float _mouseX = 0.0f;
    [SerializeField] private float _mouseY = 0.0f;

    [SerializeField] private float _xSensitivity = 2.0f;
    [SerializeField] private float _ySensitivity = 2.0f;

    [SerializeField] private float _rotateX = 0.0f;
    [SerializeField] private float _rotateY = 0.0f;

    [SerializeField] private float _maxXAngle = 80.0f;
    [SerializeField] private float _minXAngle = -45.0f;

    [SerializeField] private Vector2 _mouseMoveDir = Vector2.zero;

    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _rotateY += _mouseX * _xSensitivity;
        _rotateX -= _mouseY * _ySensitivity;

        _rotateX = Mathf.Clamp(_rotateX, _minXAngle, _maxXAngle);

        _mouseMoveDir = (_rotateY * Vector2.up) + (_rotateX * Vector2.right);
    }
}
