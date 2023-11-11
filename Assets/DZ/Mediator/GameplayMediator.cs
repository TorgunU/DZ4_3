using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayMediator
{
    private BallSpawner _ballSpawner;
    private IVictoryCondition _condition;
    private WonPanel _wonPanel;

    [Inject]
    public GameplayMediator(BallSpawner ballSpawner, IVictoryCondition condition, WonPanel wonPanel)
    {
        _ballSpawner = ballSpawner;
        _condition = condition;
        _wonPanel = wonPanel;

        _ballSpawner.Spawned += OnBallsSpawned;
        _condition.Completed += OnVictoryConditionCompleted;
    }

    private void OnDisable()
    {
        _ballSpawner.Spawned -= OnBallsSpawned;
        _condition.Completed -= OnVictoryConditionCompleted;
    }

    private void OnBallsSpawned(SpawnedBallsList spawnedBallsList)
    {
        _condition.SubscribeOnBallBursted();
    }

    private void OnVictoryConditionCompleted()
    {
        _wonPanel.Show();
    }

}
