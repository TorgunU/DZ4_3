using UnityEngine;
using Zenject;

namespace Assets.Patterns.DZ4_3
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoader();
        }

        public void BindLoader()
        {
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoaderMediator>().AsSingle();
        }
    }
}