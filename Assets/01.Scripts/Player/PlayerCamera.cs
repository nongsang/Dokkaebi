using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform _tr = null;
    [SerializeField] private Transform _playerTr = null;
    [SerializeField] private PlayerCtrl _playerCtrl = null;
    [SerializeField] private Camera _mainCamera = null;

    [SerializeField] private string[] _collisionTags;

    [SerializeField] private float _offsetHeight = 1.8f;    // 카메라가 위치할 높이
    [SerializeField] private float _minDistance = 1.0f;     // 카메라의 최소 거리
    [SerializeField] private float _maxDistance = 4.0f;     // 카메라의 최대 거리
    [SerializeField] private float _currDistance = 0.0f;    // 카메라와 대상의 현재 거리
    [SerializeField] private float _offsetDistance = 1.0f;  // 카메라의 거리를 보정하는 변수
    [SerializeField] private float _followSpeed = 20.0f;    // 카메라의 위치를 잡는 속도

    [SerializeField] private Vector3 _dollyDir = Vector3.zero; // 카메라가 있는 방향
    [SerializeField] private Vector3 _desCamPos = Vector3.zero;// 카메라를 옮길 위치

    private void Start()
    {
        _tr = GetComponent<Transform>();
        _playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _playerCtrl = _playerTr.GetComponent<PlayerCtrl>();
        _mainCamera = Camera.main;

        // 부모 오브젝트에서 카메라 지점까지 상대방향을 구한다.
        _dollyDir = _mainCamera.transform.localPosition.normalized;
    }

    private void LateUpdate()
    {
        Rotate();
        Move();
        Look();
    }

    private void FixedUpdate()
    {
        _desCamPos = _tr.TransformPoint(_dollyDir * _currDistance);

        RaycastHit hit;

        if (Physics.Raycast(_tr.position, -_tr.forward, out hit, _maxDistance))
        {
            foreach (var tag in _collisionTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    _currDistance = _maxDistance;
                    break;
                }
                else
                {
                    _currDistance = Mathf.Clamp(hit.distance - _offsetDistance, _minDistance, _maxDistance);
                }
            }
        }
        else
        {
            _currDistance = _maxDistance;
        }

        _mainCamera.transform.position = _desCamPos;
    }

    private void Rotate()
    {
        _tr.rotation = Quaternion.Euler(_playerCtrl.mouseMoveDir);
    }

    private void Move()
    {
        // 카메라는 플레이어를 따라다닌다.
        _tr.position = _playerTr.position + Vector3.up * _offsetHeight;
    }

    private void Look()
    {
        Vector3 lookPoint = _playerTr.position + Vector3.up * _offsetHeight;

        // 카메라는 어느 한 지점을 본다.
        _mainCamera.transform.LookAt(lookPoint);
    }
}
