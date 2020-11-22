using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    private PlayerStatus _playerStatus = null;
    private PlayerAnimation _playerAnimation = null;
    private PlayerSound _playerSound = null;

    [SerializeField] private int _comboNum = 0;
    public int comboNum { set => _comboNum = value; }

    private void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSound = GetComponent<PlayerSound>();
    }

    public void Attack(bool isAction)
    {
        if (!isAction)
        {
            _playerAnimation.Attack(_comboNum++ % 2);
            _playerSound.PlaySound("Attack");
        }
    }

    public void Block(bool isAction, bool block)
    {
        if (!isAction)
        {
            if (block)
            {
                _playerStatus.defence *= 2.0f;
            }
            else
            {
                _playerStatus.defence *= 0.5f;
            }
            _playerAnimation.Block(block);
        }
    }
}
