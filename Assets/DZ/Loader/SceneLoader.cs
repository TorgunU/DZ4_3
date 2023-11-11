using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Patterns.DZ4_3
{
    public class SceneLoader : ISceneLoader, ILevelDataLoader
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void Load(SceneID sceneID)
        {
            _zenjectSceneLoader.LoadScene((int)sceneID);
        }

        public void Load(SceneID sceneID, LevelLoadingData levelLoadingData)
        {
            _zenjectSceneLoader.LoadScene((int)sceneID, LoadSceneMode.Single, action =>
            {
                action.BindInstance(levelLoadingData);
            });
        }
    }
}