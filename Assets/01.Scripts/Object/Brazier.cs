using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazier : MonoBehaviour
{
    private ObjectInteraction _objectInteraction = null;

    [SerializeField] private ParticleSystem _fire = null;

    private AudioSource _audioSource = null;
    [SerializeField] private AudioClip _fireSfx = null;

    private void Start()
    {
        _objectInteraction = GetComponent<ObjectInteraction>();
        _audioSource = GetComponent<AudioSource>();

        _fire.Stop();

        StartCoroutine(ActiveCheck());
    }

    private IEnumerator ActiveCheck()
    {
        yield return new WaitUntil(() => _objectInteraction.isActive);

        _audioSource.PlayOneShot(_fireSfx);
        _fire.Play();
    }
}
