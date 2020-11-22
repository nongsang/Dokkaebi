using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float _maxHP = 100.0f;
    public float maxHP { get => _maxHP; set => _maxHP = value; }

    [SerializeField] private float _HP = 100.0f;
    public float HP { get => _HP; set => _HP = value; }

    [SerializeField] private bool _isDie = false;
    public bool isDie { get => _isDie; set => _isDie = value; }

    [SerializeField] private float _damage = 50.0f;
    public float damage { get => _damage; set => _damage = value; }

    [SerializeField] private float _defence = 30.0f;
    public float defence { get => _defence; set => _defence = value; }

    private void Start()
    {
        _maxHP = GameManager.instance.playerData.maxHP;
        _HP = GameManager.instance.playerData.HP;
        _damage = GameManager.instance.playerData.damage;
        _defence = GameManager.instance.playerData.defence;

        PlayerUICtrl.UI.SetHPBar(_HP, _maxHP);
    }
}
