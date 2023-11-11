using Assets.Patterns.DZ4_3;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChooseGameModePanel : MonoBehaviour
{
    [SerializeField] private Button _oneBallTypeSelectionButton;
    [SerializeField] private Button _allBalssTypeSelectionButton;

    private SceneLoaderMediator _sceneLoaderMediator;

    [Inject]
    private void Construct(SceneLoaderMediator sceneLoaderMediator)
    {
        _sceneLoaderMediator = sceneLoaderMediator;
    }

    private void OnEnable()
    {
        _oneBallTypeSelectionButton.onClick.AddListener(OnOneBallTypeButtonClicked);
        _allBalssTypeSelectionButton.onClick.AddListener(OnAllBallsTypeButtonClicked);
    }

    private void OnDisable()
    {
        _oneBallTypeSelectionButton.onClick.RemoveListener(OnOneBallTypeButtonClicked);
        _allBalssTypeSelectionButton.onClick.RemoveListener(OnAllBallsTypeButtonClicked);
    }

    private void OnOneBallTypeButtonClicked()
    {
        _sceneLoaderMediator.GoToGameplayScene(
            new LevelLoadingData(QuizVictoryConditionType.OneTypeBurst));
    }

    private void OnAllBallsTypeButtonClicked()
    {
        _sceneLoaderMediator.GoToGameplayScene(
            new LevelLoadingData(QuizVictoryConditionType.AllBurst));
    }
}
