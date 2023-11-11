using Assets.Patterns.DZ4_3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WonPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitToMenuButton;

    private SceneLoaderMediator _sceneLoaderMediator;
    private LevelLoadingData _levelLoadingData;

    [Inject]
    private void Construct(SceneLoaderMediator sceneLoaderMediator, LevelLoadingData data)
    {
        _sceneLoaderMediator = sceneLoaderMediator;
        _levelLoadingData = data;
    }

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        _exitToMenuButton.onClick.RemoveListener(OnExitToMenuButtonClicked);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnRestartButtonClicked()
    {
        _sceneLoaderMediator.GoToGameplayScene(_levelLoadingData);
    }

    private void OnExitToMenuButtonClicked()
    {
        _sceneLoaderMediator.GoToChoseScene();
    }
}
