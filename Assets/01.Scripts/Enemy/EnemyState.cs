using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum State { IDLE, TRACE, ATTACK, DIE }
    [SerializeField] private State _state = State.IDLE;
    public State state { get => _state; set => _state = value; }

    [SerializeField] private bool _isDie = false;
    public bool isDie { get => _isDie; set => _isDie = value; }

    private Transform _tr = null;
    private Transform _targetTr = null;
    public Transform targetTr { get => _targetTr; }

    [SerializeField] private float _attackDist = 1.0f;
    [SerializeField] private float _traceDist = 5.0f;

    private WaitForSeconds ws = null;
    [SerializeField] private float _repeatTime = 0.125f;

    private void Awake()
    {
        ws = new WaitForSeconds(_repeatTime);

        _tr = GetComponent<Transform>();
        _targetTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnEnable()
    {
        StartCoroutine(CheckState());
    }

    private void OnDisable()
    {
        StopCoroutine(CheckState());
    }

    IEnumerator CheckState()
    {
        while(!_isDie)
        {
            yield return ws;

            if (_state == State.DIE) yield break;

            float dist = Vector3.Distance(_targetTr.position, _tr.position);

            if (dist <= _attackDist)
            {
                _state = State.ATTACK;
            }
            else if (dist <= _traceDist)
            {
                _state = State.TRACE;
            }
            else
            {
                _state = State.IDLE;
            }
        }
    }
}
