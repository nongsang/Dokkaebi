using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeCg = null;

    [Range(0.5f, 2.0f)]
    [SerializeField] private float _fadeDuration = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _startAlpha = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _desAlpha = 0.0f;

    [SerializeField] private string _sceneName = "Field";

    private void Start()
    {
        _fadeCg.alpha = _startAlpha;

        _sceneName = GameManager.instance.playerData.currStage;

        StartCoroutine(LoadScene(_sceneName));
        StartCoroutine(Fade(_desAlpha));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    IEnumerator Fade(float desAlpha)
    {
        _fadeCg.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(_fadeCg.alpha - desAlpha) / _fadeDuration;

        while(!Mathf.Approximately(_fadeCg.alpha, desAlpha))
        {
            _fadeCg.alpha = Mathf.MoveTowards(_fadeCg.alpha, desAlpha, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        _fadeCg.blocksRaycasts = false;

        SceneManager.UnloadSceneAsync("Loading");
    }
}
