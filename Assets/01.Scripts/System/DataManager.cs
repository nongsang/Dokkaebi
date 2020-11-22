using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataInfo;

public class DataManager : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerDataScriptableObject = null;

    public void SavePlayerData(PlayerData playerData)
    {
        _playerDataScriptableObject.currStage = playerData.currStage;
        _playerDataScriptableObject.maxHP = playerData.maxHP;
        _playerDataScriptableObject.HP = playerData.HP;
        _playerDataScriptableObject.damage = playerData.damage;
        _playerDataScriptableObject.defence = playerData.defence;
        _playerDataScriptableObject.HPPosionCnt = playerData.HPPosionCnt;
    }

    public PlayerData LoadPlayerData()
    {
        PlayerData playerData = new PlayerData();

        playerData.currStage = _playerDataScriptableObject.currStage;
        playerData.maxHP = _playerDataScriptableObject.maxHP;
        playerData.HP = _playerDataScriptableObject.HP;
        playerData.damage = _playerDataScriptableObject.damage;
        playerData.defence = _playerDataScriptableObject.defence;
        playerData.HPPosionCnt = _playerDataScriptableObject.HPPosionCnt;

        return playerData;
    }
}
