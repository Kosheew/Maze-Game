using UnityEngine;
using UnityEngine.UI;
using Menu_View;

public class MainView : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private Slider loadSlider;

    private IMainPresenter _mainPresenter;

    public void Init(IMainPresenter presenter)
    {
        _mainPresenter = presenter;

        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(_mainPresenter.ExitGame);
    }

    private void OnStartButtonClicked()
    {
        loadingCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        _mainPresenter.StartGame(loadSlider);
    }
}