using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Create PlayerData", order = 1)]
public class PlayerDataScriptableObject : ScriptableObject
{
    [SerializeField] private string _currStage = "Tutorial";
    public string currStage { get => _currStage; set => _currStage = value; }

    [SerializeField] private float _maxHP = 100.0f;
    public float maxHP { get => _maxHP; set => _maxHP = value; }

    [SerializeField] private float _HP = 100.0f;
    public float HP { get => _HP; set => _HP = value; }

    [SerializeField] private float _damage = 50.0f;
    public float damage { get => _damage; set => _damage = value; }

    [SerializeField] private float _defence = 30.0f;
    public float defence { get => _defence; set => _defence = value; }

    [SerializeField] private int _HPPosionCnt = 5;
    public int HPPosionCnt { get => _HPPosionCnt; set => _HPPosionCnt = value; }
}
