using System;

public abstract class VictoryCondition : IVictoryCondition, IDisposable
{
    protected SpawnedBallsList SpawnedBalls;

    protected VictoryCondition(SpawnedBallsList spawnedBallsList)
    {
        SpawnedBalls = spawnedBallsList;
    }

    public void SubscribeOnBallBursted()
    {
        SpawnedBalls.Balls.ForEach(ball => { ball.Bursted += OnBallBursted; });
    }

    public void Dispose()
    {
        if (SpawnedBalls == null)
            return;

        SpawnedBalls.Balls.ForEach(ball => { ball.Bursted -= OnBallBursted; });
    }

    protected void OnBallBursted(Ball ball)
    {
        ball.Bursted -= OnBallBursted;
        CheckCondition();
    }

    protected abstract void CheckCondition();

    public abstract event Action Completed;
}
