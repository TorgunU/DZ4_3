using System.Collections.Generic;

public class SpawnedBallsList
{
    private List<Ball> _balls;

    public SpawnedBallsList(BallsSpawnPositions ballsSpawnPositions)
    {
        _balls = new List<Ball>(ballsSpawnPositions.Positions.Count);
    }

    public List<Ball> Balls => _balls;
}
