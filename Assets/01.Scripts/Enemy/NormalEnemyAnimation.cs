using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAnimation : MonoBehaviour
{
    private Animator _anim = null;

    [SerializeField] private string[] _attackNames = null;
    private int[] _hashAttackNames = null;

    private readonly int hashTrace = Animator.StringToHash("Trace");
    private readonly int hashAttack = Animator.StringToHash("Attack");
    private readonly int hashLightHit = Animator.StringToHash("LightHit");
    private readonly int hashDie = Animator.StringToHash("Die");

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
        _anim.SetBool(hashTrace, false);
    }

    public void Trace()
    {
        _anim.SetBool(hashTrace, true);
    }

    public void Attack()
    {
        foreach (var elem in _hashAttackNames)
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).fullPathHash == elem)
            {
                return;
            }
        }

        _anim.SetBool(hashTrace, false);
        _anim.SetTrigger(hashAttack);
    }

    public void LightHit()
    {
        _anim.SetTrigger(hashLightHit);
    }

    public void Die()
    {
        _anim.SetTrigger(hashDie);
    }
}
