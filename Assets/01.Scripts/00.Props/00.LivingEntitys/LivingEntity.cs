using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using JetBrains.Annotations;

public class LivingEntity : MonoBehaviour, IDamageable
{
    public int Level = 1;   // 레벨
    public int Exp = 0;     // 경험치

    public int Str = 0;     // 힘
    public int Dex = 0;     // 손재주
    public int Con = 0;     // 건강

    public float Atk = 10.0f;    // 공격력
    public float Def = 10.0f;    // 방어력

    public float maxHealth = 100.0f;
    public float maxStamina = 100.0f;
    public float currHealth;
    public float currStamina;
    public bool dead = false;

    public Action onDeath;

    protected virtual void Start()
    {
        currHealth = maxHealth;
        currStamina = maxStamina;
    }

    public virtual void RestoreHealth(float health)
    {
        if(dead)
        {
            return;
        }

        currHealth = Mathf.Clamp(currHealth + health, 0, maxHealth);
    }

    public virtual void OnDamage(float damage)
    {
        currHealth -= damage;

        if(currHealth <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //if(onDeath != null)
        //{
        //    onDeath();
        //}

        onDeath?.Invoke();  // 위 조건식을 간단하게 한 것

        dead = true;
    }
}
