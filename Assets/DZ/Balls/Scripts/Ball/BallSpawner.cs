using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    private BallFactory _factory;
    private BallsSpawnPositions _positions;
    private SpawnedBallsList _spawnedList;
    private List<BallType> _types = new List<BallType>();

    [Inject]
    private void Construct(BallFactory factory, BallsSpawnPositions ballsPositions, 
        SpawnedBallsList spawnedBallsList)
    {
        _factory = factory;
        _positions = ballsPositions;
        _spawnedList = spawnedBallsList;

        foreach (BallType type in Enum.GetValues(typeof(BallType)))
        {
            _types.Add(type);
        }
    }

    private void Awake()
    {
       StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        int spawnCounter = 0;

        yield return new WaitWhile(() =>
        {
            if (spawnCounter % _types.Count == 0)
            {
                ShuffleColors();
            }

            Ball ball = _factory.CreateBall(
                _types[spawnCounter % _types.Count], 
                _positions.Positions[spawnCounter], 
                transform);
            _spawnedList.Balls.Add(ball);
            spawnCounter++;
            return spawnCounter < _positions.Positions.Count;
        });
        Spawned?.Invoke(_spawnedList);
    }

    private void ShuffleColors()
    {
        for (int i = _types.Count - 1; i > 0; i--)
        {
            int randomNumber = UnityEngine.Random.Range(0, i + 1);
            BallType type = _types[randomNumber];
            _types[randomNumber] = _types[i];
            _types[i] = type;
        }
    }

    public event Action<SpawnedBallsList> Spawned;
}
