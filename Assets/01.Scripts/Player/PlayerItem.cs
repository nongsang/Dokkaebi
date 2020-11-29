using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    private PlayerStatus _playerStatus = null;
    private PlayerSound _playerSound = null;
    [SerializeField] private ParticleSystem _recoveryEffect = null;

    public enum Item { HPPosion };
    [SerializeField] private Item _item = Item.HPPosion;

    [SerializeField] private int _maxHPPotionCnt = 5;
    [SerializeField] private int _currHPPosionCnt = 5;

    private void Start()
    {
        _playerStatus = GetComponent<PlayerStatus>();
        _playerSound = GetComponent<PlayerSound>();
        _currHPPosionCnt = GameManager.instance.playerData.HPPosionCnt;
        PlayerUICtrl.UI.SetItemCnt(_currHPPosionCnt);
        _recoveryEffect.Stop();
    }

    public void UseItem()
    {
        switch(_item)
        {
            case Item.HPPosion:
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

            HealSfx();

            PlayerUICtrl.UI.SetHPBar(_playerStatus.HP, _playerStatus.maxHP);
            PlayerUICtrl.UI.SetItemCnt(_currHPPosionCnt);

            GameManager.instance.playerData.HP = _playerStatus.HP;
        }
    }

    private void HealSfx()
    {
        _recoveryEffect.Play();
        _playerSound.PlaySound("Recovery");
    }
}
