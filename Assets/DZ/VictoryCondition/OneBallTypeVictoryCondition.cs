using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class OneBallTypeVictoryCondition : VictoryCondition
{
    private BallType _ballType;

    public OneBallTypeVictoryCondition(SpawnedBallsList spawnedBalls, BallType ballType) 
        : base(spawnedBalls)
    {
        _ballType = ballType;
        Debug.Log("Òèï:" + _ballType);
    }

    protected override void CheckCondition()
    {
        if (SpawnedBalls.Balls.FindAll(ball => ball.BallType == _ballType)
            .Any(ball => ball.IsBursted == false))
        {
            Debug.Log("Try");
            return;
        }

        Debug.Log("Completed");
        Completed?.Invoke();
    }

    public override event Action Completed;
}
