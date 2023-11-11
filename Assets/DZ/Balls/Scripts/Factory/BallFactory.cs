using System;
using System.IO;
using UnityEngine;
using Zenject;

public class BallFactory
{
    private const string ConfigPath = "BallConfigs";
    private const string RedBallConfig = "RedBallConfig";
    private const string GreeBallConfig = "GreenBallConfig";
    private const string BlueBallConfig = "BlueBallConfig";

    private BallConfig _redBallConfig, _greenBallConfig, _blueBallConfig;
    private DiContainer _container;

    private BallFactory(DiContainer container)
    {
        _container = container;
        LoadConfigs();
    }

    private void LoadConfigs()
    {
        _redBallConfig = Resources.Load<BallConfig>(Path.Combine(ConfigPath, RedBallConfig));
        _greenBallConfig = Resources.Load<BallConfig>(Path.Combine(ConfigPath, GreeBallConfig));
        _blueBallConfig = Resources.Load<BallConfig>(Path.Combine(ConfigPath, BlueBallConfig));
    }

    public Ball CreateBall(BallType type, Transform ballTransform, Transform parent)
    {
        BallConfig config = GetConfig(type);
        Ball ball = _container.InstantiatePrefabForComponent<Ball>(config.Prefab,
            ballTransform.position, ballTransform.rotation, parent);
        ball.Init(config.BallType);
        return ball;
    }

    private BallConfig GetConfig(BallType type)
    {
        switch (type)
        {
            case BallType.Red:
                return _redBallConfig;

            case BallType.Green:
                return _greenBallConfig;

            case BallType.Blue:
                return _blueBallConfig;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
