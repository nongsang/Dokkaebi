using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _cc = null;
    private PlayerAnimation _playerAnimation = null;
    [SerializeField] private GameObject _playerCharacter = null;

    [SerializeField] private float _currMoveSpeed = 10.0f;
    [SerializeField] private float _blockMoveSpeed = 5.0f;
    [SerializeField] private float _runMoveSpeed = 10.0f;
    [SerializeField] private float _currRotateSpeed = 45.0f;

    private void Start()
    {
        _cc = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void MovePlayer(Vector3 moveDir, Quaternion rotateDir, bool isAction, bool isBlock)
    {
        _playerCharacter.transform.rotation = rotateDir;

        if(isBlock)
        {
            _currMoveSpeed = _blockMoveSpeed;
        }
        else
        {
            _currMoveSpeed = _runMoveSpeed;
        }

        if (!isAction)
        {
            _cc.SimpleMove(moveDir.normalized * _currMoveSpeed);

            _playerAnimation.Move(moveDir.sqrMagnitude);
        }
    }

    public void RotateCharacter(float rotateY)
    {
        _cc.transform.rotation = Quaternion.Euler(0.0f, rotateY, 0.0f);
    }
}
