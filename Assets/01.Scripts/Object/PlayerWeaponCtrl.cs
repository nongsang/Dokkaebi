using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCtrl : MonoBehaviour
{
    private PlayerStatus _playerStatus = null;
    [SerializeField] private float _damage = 0.0f;
    public float damage { get => _damage; }

    void Start()
    {
        _playerStatus = transform.root.GetComponent<PlayerStatus>();
        _damage = _playerStatus.damage;
    }
}
