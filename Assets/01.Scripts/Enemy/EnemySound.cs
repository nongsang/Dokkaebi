using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    private AudioSource _audioSource = null;
    [SerializeField] private string[] _behaviours = null;
    [SerializeField] private AudioClip[] _sounds = null;

    private Dictionary<string, AudioClip> _behaviourSounds = new Dictionary<string, AudioClip>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < _behaviours.Length; ++i)
        {
            _behaviourSounds.Add(_behaviours[i], _sounds[i]);
        }
    }

    public void PlaySound(string behaviour)
    {
        _audioSource.PlayOneShot(_behaviourSounds[behaviour]);
    }
}
