using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private AudioManager _audioManager = null;

    private void Start()
    {
        _audioManager = Camera.main.GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _audioManager.PlayerBGM("Boss");
        }
    }
}
