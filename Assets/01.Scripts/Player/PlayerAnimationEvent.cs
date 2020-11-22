using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerCtrl _playerCtrl = null;
    private PlayerBattle _playerBattle = null;

    private void Start()
    {
        _playerCtrl = transform.root.GetComponent<PlayerCtrl>();
        _playerBattle = transform.root.GetComponent<PlayerBattle>();
    }

    public void ActionReady()
    {
        _playerCtrl.isAction = false;
    }

    public void ComboInit()
    {
        _playerBattle.comboNum = 0;
    }
}
