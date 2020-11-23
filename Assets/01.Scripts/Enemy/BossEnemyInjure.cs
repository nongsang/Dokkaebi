using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyInjure : MonoBehaviour
{
    private EnemyStatus _enemyStatus = null;
    private EnemyState _enemyState = null;

    [SerializeField] private string _collisionTag = "Weapon";

    private void Start()
    {
        _enemyStatus = GetComponent<EnemyStatus>();
        _enemyState = GetComponent<EnemyState>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_collisionTag))
        {
            float damage = other.GetComponent<PlayerWeaponCtrl>().damage - _enemyStatus.defence;

            if (damage < 0.0f)
            {
                damage = 0.0f;
            }

            _enemyStatus.HP -= damage;

            if (_enemyStatus.HP <= 0.0f)
            {
                _enemyState.state = EnemyState.State.DIE;
            }
        }
    }
}
