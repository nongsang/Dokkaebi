using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource = null;
    [SerializeField] private string _currStage = null;
    [SerializeField] private string[] _sceneName = null;
    [SerializeField] private AudioClip[] _backGroundMusics = null;

    public Dictionary<string, AudioClip> _sceneBackGroundMusics = new Dictionary<string, AudioClip>();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _currStage = GameManager.instance.playerData.currStage;

        for (int i = 0; i < _sceneName.Length; ++i)
        {
            _sceneBackGroundMusics.Add(_sceneName[i], _backGroundMusics[i]);
        }

        PlayerBGM(_currStage);
    }

    public void PlayerBGM(string sceneName)
    {
        _audioSource.clip = _sceneBackGroundMusics[sceneName];
        _audioSource.Play();
    }
}
