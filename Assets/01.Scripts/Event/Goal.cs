using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private ObjectInteraction _objectInteraction = null;

    [SerializeField] private CanvasGroup _fadeCg = null;
    [Range(0.5f, 2.0f)]
    [SerializeField] private float _fadeDuration = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _desAlpha = 1.0f;

    private AudioSource _playerAudioSource = null; 

    private void Start()
    {
        _objectInteraction = GetComponent<ObjectInteraction>();
        _playerAudioSource = Camera.main.GetComponent<AudioSource>();

        StartCoroutine(ActiveCheck());
    }

    private IEnumerator ActiveCheck()
    {
        yield return new WaitUntil(() => _objectInteraction.isActive);

        StartCoroutine(Fade(_desAlpha));
        _playerAudioSource.Stop();
    }

    IEnumerator Fade(float desAlpha)
    {
        _fadeCg.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(_fadeCg.alpha - desAlpha) / _fadeDuration;

        while (!Mathf.Approximately(_fadeCg.alpha, desAlpha))
        {
            _fadeCg.alpha = Mathf.MoveTowards(_fadeCg.alpha, desAlpha, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _fadeCg.blocksRaycasts = false;
    }
}
