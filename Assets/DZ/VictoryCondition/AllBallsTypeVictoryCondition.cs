using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllBallsTypeVictoryCondition : VictoryCondition
{
    public AllBallsTypeVictoryCondition(SpawnedBallsList spawnedBalls) : base(spawnedBalls)
    { }

    protected override void CheckCondition()
    {
        if (SpawnedBalls.Balls.Any(ball => ball.IsBursted == false))
        {
            return;
        }

        Debug.Log("Completed");
        Completed?.Invoke();
    }

    public override event Action Completed;
}
