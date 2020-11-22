using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] private bool _isActive = false;
    public bool isActive { get => _isActive; set => _isActive = value; }

    [SerializeField] private bool _isRepeat = true;

    private WaitForSeconds ws = null;
    [SerializeField] private float _seconds = 0.25f;

    private void Awake()
    {
        ws = new WaitForSeconds(_seconds);
    }

    private void OnEnable()
    {
        StartCoroutine(ActiveCheck());
    }

    private void OnDisable()
    {
        StopCoroutine(ActiveCheck());
    }

    private IEnumerator ActiveCheck()
    {
        while (_isRepeat)
        {
            if (_isActive)
            {
                _isActive = false;
            }

            yield return ws;
        }
    }
}
