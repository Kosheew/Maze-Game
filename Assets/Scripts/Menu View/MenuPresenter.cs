using Scene_Manager;
using Loader;
using UnityEngine;

public class MenuPresenter
{
    private readonly SceneLoader _sceneLoader;
    private readonly SceneController _sceneController;
    
    public MenuPresenter(SceneLoader sceneLoader, SceneController sceneController)
    {
        _sceneLoader = sceneLoader;
        _sceneController = sceneController;
    }

    public void StartGame()
    {
        _sceneLoader.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}