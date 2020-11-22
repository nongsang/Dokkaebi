using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyState))]
public class BossEnemy : MonoBehaviour
{
    private NavMeshAgent _agent = null;
    private EnemyState _enemyState = null;
    private BossEnemyAnimation _bossEnemyAnimation = null;

    private WaitForSeconds ws = null;
    [SerializeField] private float _time = 0.0625f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyState = GetComponent<EnemyState>();
        _bossEnemyAnimation = GetComponent<BossEnemyAnimation>();

        ws = new WaitForSeconds(_time);
    }

    private void OnEnable()
    {
        StartCoroutine(Action());
        PlayerInjure.OnPlayerDie += this.OnPlayerDie;
    }

    private void OnDisable()
    {
        PlayerInjure.OnPlayerDie -= this.OnPlayerDie;
        StopCoroutine(Action());
    }

    private IEnumerator Action()
    {
        while (!_enemyState.isDie)
        {
            yield return ws;

            switch (_enemyState.state)
            {
                case EnemyState.State.IDLE:
                    _agent.isStopped = true;
                    _bossEnemyAnimation.Idle();
                    break;
                case EnemyState.State.TRACE:
                    _agent.isStopped = false;
                    _agent.destination = _enemyState.targetTr.position;
                    _bossEnemyAnimation.Trace();
                    break;
                case EnemyState.State.ATTACK:
                    _agent.isStopped = true;
                    _bossEnemyAnimation.Attack(_enemyState.targetTr.position);
                    break;
                case EnemyState.State.DIE:
                    _enemyState.isDie = true;
                    _agent.isStopped = true;
                    GetComponent<Collider>().enabled = false;
                    _bossEnemyAnimation.Die();
                    break;
            }
        }
    }
    private void OnPlayerDie()
    {
        StopAllCoroutines();
    }
}
