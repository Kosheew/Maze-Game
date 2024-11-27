using UnityEngine.UI;
using Menu_View;
using UnityEngine;

public class MainPresenter : IMainPresenter
{
    private readonly ISceneLoader _sceneLoader;

    public MainPresenter(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void StartGame(Slider slider)
    {
        _sceneLoader.LoadSceneAsync(1, slider);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}