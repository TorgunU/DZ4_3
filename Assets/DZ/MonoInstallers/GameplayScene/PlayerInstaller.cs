using Cinemachine;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    private Player _player;

    public override void InstallBindings()
    {
        InstallPlayer();
        InstallCamera();
    }

    private void InstallPlayer()
    {
        _player = Container.InstantiatePrefabForComponent<Player>(_playerPrefab);
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(_player).AsSingle();
    }

    private void InstallCamera()
    {
        _virtualCamera.Follow = _player.transform;
    }
}