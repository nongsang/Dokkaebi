using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform _tr = null;
    private PlayerStatus _playerStatus = null;
    private PlayerMovement _playerMovement = null;
    private PlayerBattle _playerBattle = null;
    private PlayerItem _playerItem = null;
    private PlayerInteraction _playerInteraction = null;

    [SerializeField] private GameObject _playerCharacter = null;

    // 이동 입력
    [SerializeField] private float _verticalInput = 0.0f;
    [SerializeField] private float _horizontalInput = 0.0f;

    [SerializeField] private Vector3 _moveDir = Vector3.zero;

    // 회전 입력
    [SerializeField] private float _mouseX = 0.0f;
    [SerializeField] private float _mouseY = 0.0f;

    [SerializeField] private float _xSensitivity = 2.0f;
    [SerializeField] private float _ySensitivity = 2.0f;

    [SerializeField] private float _rotateX = 0.0f;
    [SerializeField] private float _rotateY = 0.0f;

    [SerializeField] private float _maxXAngle = 80.0f;
    [SerializeField] private float _minXAngle = -30.0f;

    [SerializeField] private Vector2 _mouseMoveDir = Vector2.zero;
    public Vector2 mouseMoveDir { get => _mouseMoveDir; }
    [SerializeField] private Quaternion _rotateDir = Quaternion.identity;

    // 전투 입력
    [SerializeField] private bool _isAction = false;
    public bool isAction { set => _isAction = value; }
    [SerializeField] private bool _isBlock = false;

    // 상호작용 입력

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _tr = GetComponent<Transform>();
        _playerStatus = GetComponent<PlayerStatus>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerBattle = GetComponent<PlayerBattle>();
        _playerItem = GetComponent<PlayerItem>();
        _playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        if (!_playerStatus.isDie)
        {
            GetInputRotate();
            GetInputMove();
            _playerMovement.MovePlayer(_moveDir, _rotateDir, _isAction, _isBlock);
            GetInputBattle();
            GetInputUseItem();
            GetInputInteraction();
        }
    }

    private void LateUpdate()
    {
        _playerMovement.RotateCharacter(_mouseMoveDir);
    }

    private void GetInputMove()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");

        _moveDir = (_verticalInput * _tr.forward) + (_horizontalInput * _tr.right);

        if (_moveDir.sqrMagnitude != 0 && !_isAction)
        {
            _rotateDir = Quaternion.LookRotation(_moveDir);
        }
    }

    private void GetInputRotate()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _rotateY += _mouseX * _xSensitivity;
        _rotateX -= _mouseY * _ySensitivity;

        _rotateX = Mathf.Clamp(_rotateX, _minXAngle, _maxXAngle);

        _mouseMoveDir = new Vector2(_rotateX, _rotateY);
    }

    private void GetInputBattle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerBattle.Attack(_isAction);
            _isAction = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _playerBattle.Block(_isAction, true);
            _isBlock = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _playerBattle.Block(_isAction, false);
            _isBlock = false;
        }
    }
    
    private void GetInputUseItem()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _playerItem.UseItem();
        }
    }

    private void GetInputInteraction()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _playerInteraction.Active();
        }
    }
}
