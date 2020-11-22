using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private PlayerStatus _playerStatus = null;
    private AudioSource _audioSource = null;
    [SerializeField] private AudioClip _healSound = null;
    [SerializeField] private ParticleSystem _healEffect = null;

    public enum Item { HPPosion };
    [SerializeField] private Item _item = Item.HPPosion;

    [SerializeField] private int _maxHPPotionCnt = 5;
    [SerializeField] private int _currHPPosionCnt = 5;

    private void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _audioSource = GetComponent<AudioSource>();
        _currHPPosionCnt = GameManager.instance.playerData.HPPosionCnt;
        PlayerUICtrl.UI.SetItemCnt(_currHPPosionCnt);
        _healEffect.Stop();
    }

    public void UseItem()
    {
        switch(_item)
        {
            case Item.HPPosion:
                _healEffect.Play();
                UseHPPosion();
                break;
        }

        GameManager.instance.playerData.HPPosionCnt = _currHPPosionCnt;
    }

    private void UseHPPosion()
    {
        if (_currHPPosionCnt > 0)
        {
            _currHPPosionCnt--;

            if (_playerStatus.HP + 50.0f >= _playerStatus.maxHP)
            {
                _playerStatus.HP = _playerStatus.maxHP;
            }
            else
            {
                _playerStatus.HP += 50.0f;
            }

            PlayerUICtrl.UI.SetHPBar(_playerStatus.HP, _playerStatus.maxHP);
            PlayerUICtrl.UI.SetItemCnt(_currHPPosionCnt);

            HealSfx();

            GameManager.instance.playerData.HP = _playerStatus.HP;
        }
    }

    private void HealSfx()
    {
        _audioSource.PlayOneShot(_healSound);
    }
}
