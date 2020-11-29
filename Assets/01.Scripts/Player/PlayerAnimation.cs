using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator = null;

    private readonly int _hashMove = Animator.StringToHash("Move");
    private readonly int _hashComboNum = Animator.StringToHash("comboNum");
    private readonly int _hashAttack = Animator.StringToHash("Attack");
    private readonly int _hashBlock = Animator.StringToHash("Block");
    private readonly int _hashDie = Animator.StringToHash("Die");

    private void Start()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Move(float moveInput)
    {
        _animator.SetFloat(_hashMove, moveInput);
    }

    public void Attack(int comboNum)
    {
        _animator.SetInteger(_hashComboNum, comboNum);
        _animator.SetTrigger(_hashAttack);
    }

    public void Block(bool isBlock)
    {
        _animator.SetBool(_hashBlock, isBlock);
    }

    public void Die()
    {
        _animator.SetTrigger(_hashDie);
    }
}
