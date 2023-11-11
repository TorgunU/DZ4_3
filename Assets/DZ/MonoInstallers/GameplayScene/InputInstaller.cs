using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private DesktopInput _desktopInputPrefab;

    public override void InstallBindings()
    {
        InstallInputAction();
        InstallPlayerInput();
    }

    private void InstallInputAction()
    {
        Container.Bind<InputAction>().FromNew().AsSingle().NonLazy();
    }

    private void InstallDesktopInput()
    {
        DesktopInput keyboard = Container.InstantiatePrefabForComponent<DesktopInput>(_desktopInputPrefab);
        Container.BindInterfacesAndSelfTo<DesktopInput>().FromInstance(keyboard)
            .AsSingle().NonLazy();
    }

    private void InstallPlayerInput()
    {
        switch (SystemInfo.deviceType) 
        {
            case DeviceType.Desktop:
                InstallDesktopInput();
                break;

            default:
                throw new ArgumentException("Cant Install Unknown's Input");
        }
    }


}
