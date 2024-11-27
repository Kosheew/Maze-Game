using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Menu_View;

public class LoadingScene : MonoBehaviour, ISceneLoader
{   
    public void LoadSceneAsync(int sceneIndex, Slider loadSlider)
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex, loadSlider));
    }

    private IEnumerator LoadSceneCoroutine(int indexScene, Slider loadSlider)
    {
        var loadOperation = SceneManager.LoadSceneAsync(indexScene);

        var progressValue = 0f;
        loadSlider.value = progressValue;

        while (loadOperation is { isDone: false })
        {
            progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadSlider.value = progressValue;
            yield return null;
        } 
    }
}
