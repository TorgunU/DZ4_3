using Assets.Patterns.DZ4_3;
using UnityEngine;

public class Level
{
    private IVictoryCondition _victoryCondition;

    public Level(IVictoryCondition victoryCondition)
    {
        _victoryCondition = victoryCondition;
        _victoryCondition.Completed += OnVictoryCompleted;
    }

    public void OnVictoryCompleted()
    {
        Debug.Log("Победа!");
    }
}
