using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayMediatorInstaller : MonoInstaller
{
    [SerializeField] private WonPanel _wonPanel;

    public override void InstallBindings()
    {
        InstallWonPanel();
        InstallGameplayMediator();

    }

    private void InstallWonPanel()
    {
        Container.BindInterfacesAndSelfTo<WonPanel>().FromInstance(_wonPanel)
            .AsSingle().NonLazy();
    }

    private void InstallGameplayMediator()
    {
        Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle().NonLazy();
    }
}
