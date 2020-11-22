using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICtrl : MonoBehaviour
{
    public static PlayerUICtrl UI = null;

    [SerializeField] private Image _imageHP = null;
    [SerializeField] private Text _posionCnt = null;

    private void Awake()
    {
        if(!UI)
        {
            UI = this;
        }
        else if(UI != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetHPBar(float HP, float maxHP)
    {
        _imageHP.fillAmount = HP / maxHP;
    }

    public void SetItemCnt(int value)
    {
        _posionCnt.text = value.ToString();
    }
}
