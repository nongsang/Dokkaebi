using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponCtrl : MonoBehaviour
{
    private EnemyStatus _enemyStatus = null;
    [SerializeField] private float _damage = 0.0f;
    public float damage { get => _damage; }

    void Start()
    {
        _enemyStatus = transform.root.GetComponent<EnemyStatus>();
        _damage = _enemyStatus.damage;
    }
}
