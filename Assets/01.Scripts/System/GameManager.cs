using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataInfo;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private DataManager _dataManager = null;

    [SerializeField] private bool _isGameOver = false;
    public bool isGameOver { get => _isGameOver; set => _isGameOver = value; }

    [SerializeField] private PlayerData _playerData = null;
    public PlayerData playerData { get => _playerData; set => _playerData = value; }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        _dataManager = GetComponent<DataManager>();

        Load();
    }

    public void InitData()
    {
        playerData.currStage = "Tutorial";
        playerData.maxHP = 100.0f;
        playerData.HP = 100.0f;
        playerData.damage = 50.0f;
        playerData.defence = 30.0f;
        playerData.HPPosionCnt = 5;
    }

    public void Save()
    {
        _dataManager.SavePlayerData(_playerData);
    }

    public void Load()
    {
        _playerData = _dataManager.LoadPlayerData();
    }

    private void OnApplicationQuit()
    {
        InitData();
        Save();
    }
}
