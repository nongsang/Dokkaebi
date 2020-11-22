using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim = null;

    private void Start()
    {
        _anim = transform.GetChild(0).GetComponent<Animator>();
    }

    public void Move(float moveInput)
    {
        _anim.SetFloat("Move", moveInput);
    }

    public void Attack(int comboNum)
    {
        _anim.SetInteger("comboNum", comboNum);
        _anim.SetTrigger("Attack");
    }

    public void Block(bool value)
    {
        _anim.SetBool("Block", value);
    }

    public void Roll()
    {
        _anim.SetTrigger("Roll");
    }

    public void Die()
    {
        _anim.SetTrigger("Die");
    }
}
