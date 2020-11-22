using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour
{
    [SerializeField] private string _currSceneName = "Tutorial";
    [SerializeField] private string _loadSceneName = "Field";

    [SerializeField] private CanvasGroup _fadeCg = null;
    [Range(0.5f, 2.0f)]
    [SerializeField] private float _fadeDuration = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _desAlpha = 1.0f;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.playerData.currStage = "Field";
            GameManager.instance.Save();

            StartCoroutine(Fade(_desAlpha));
        }
    }

    IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);

        SceneManager.UnloadSceneAsync(_currSceneName);
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

        StartCoroutine(LoadScene());
    }
}
