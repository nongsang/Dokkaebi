using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInjure : MonoBehaviour
{
    private PlayerStatus _playerStatus = null;
    private PlayerAnimation _playerAnimation = null;

    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    [SerializeField] private string _collisionTag = "EnemyWeapon";

    private void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            float damage = other.GetComponent<EnemyWeaponCtrl>().damage - _playerStatus.defence;

            if (damage < 0.0f)
            {
                damage = 0.0f;
            }

            _playerStatus.HP -= damage;
            GameManager.instance.playerData.HP = _playerStatus.HP;

            PlayerUICtrl.UI.SetHPBar(_playerStatus.HP, _playerStatus.maxHP);

            if (_playerStatus.HP <= 0.0f)
            {
                _playerStatus.isDie = true;
                _playerAnimation.Die();
                GetComponent<Collider>().enabled = false;
                PlayerDieEvent();
            }
        }
    }

    private void PlayerDieEvent()
    {
        OnPlayerDie();
    }
}
