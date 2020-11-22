using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private float _HP = 100.0f;
    public float HP { get => _HP; set => _HP = value; }

    [SerializeField] private float _damage = 40.0f;
    public float damage { get => _damage; }

    [SerializeField] private float _defence = 10.0f;
    public float defence { get => _defence; }
}
