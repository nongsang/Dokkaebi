using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAnimation : MonoBehaviour
{
    private Animator _anim = null;

    [SerializeField] private string[] _attackNames = null;
    private int[] _hashAttackNames = null;

    private readonly int _hashTrace = Animator.StringToHash("Trace");
    private readonly int _hashAttack = Animator.StringToHash("Attack");
    private readonly int _hashAttackIndex = Animator.StringToHash("AttackIndex");
    private readonly int _hashDie = Animator.StringToHash("Die");

    private void Awake()
    {
        _anim = GetComponent<Animator>();

        _hashAttackNames = new int[_attackNames.Length];

        for (int i = 0; i < _attackNames.Length; ++i)
        {
            _hashAttackNames[i] = Animator.StringToHash(_attackNames[i]);
        }
    }

    public void Idle()
    {
        _anim.SetBool(_hashTrace, false);
    }

    public void Trace()
    {
        _anim.SetBool(_hashTrace, true);
    }

    public void Attack(Vector3 traceTarget)
    {
        foreach (var elem in _hashAttackNames)
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).fullPathHash == elem)
            {
                return;
            }
        }

        transform.LookAt(traceTarget);
        _anim.SetBool(_hashTrace, false);
        _anim.SetInteger(_hashAttackIndex, Random.Range(0, 3));
        _anim.SetTrigger(_hashAttack);
    }

    public void Die()
    {
        _anim.SetTrigger(_hashDie);
    }
}
