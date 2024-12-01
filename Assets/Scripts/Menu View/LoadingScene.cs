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

        float displayedProgress = 0f;
        var targetProgress = 0f;
        loadSlider.value = displayedProgress;

        while (!loadOperation.isDone)
        {
            targetProgress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            
            displayedProgress = Mathf.MoveTowards(displayedProgress, targetProgress, Time.deltaTime); 
            loadSlider.value = displayedProgress;
            
            yield return null;
        } 
    }
}
