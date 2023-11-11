using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class BallSpawnerInstaller : MonoInstaller
{
    [SerializeField] private BallsSpawnPositions _positions;
    [SerializeField] private BallSpawner _spawner;

    public override void InstallBindings()
    {
        InstallFactory();
        InstallBallsPositions();
        InstallSpawnedBallsList();
        InstallSpawner();
    }

    private void InstallFactory()
    {
        Container.Bind<BallFactory>().AsSingle();
    }

    private void InstallBallsPositions()
    {
        BallsSpawnPositions positions = Container.InstantiatePrefabForComponent<BallsSpawnPositions>(_positions);
        Container.BindInterfacesAndSelfTo<BallsSpawnPositions>().FromInstance(positions).AsSingle();
    }

    private void InstallSpawnedBallsList()
    {
        Container.BindInterfacesAndSelfTo<SpawnedBallsList>().AsSingle();
    }

    private void InstallSpawner()
    {
        BallSpawner spawner = Container.InstantiatePrefabForComponent<BallSpawner>(_spawner);
        Container.BindInterfacesAndSelfTo<BallSpawner>().FromInstance(spawner).AsSingle();
    }
}
