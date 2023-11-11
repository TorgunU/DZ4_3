using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Patterns.DZ4_3
{
    public class SceneLoaderMediator : ISceneLoadMediator
    {
        private ISceneLoader _sceneLoader;
        private ILevelDataLoader _levelDataLoader;

        public SceneLoaderMediator(ISceneLoader sceneLoader, ILevelDataLoader levelDataLoader)
        {
            _sceneLoader = sceneLoader;
            _levelDataLoader = levelDataLoader;
        }

        public void GoToChoseScene()
        {
            _sceneLoader.Load(SceneID.QuizChooseMenu);
        }

        public void GoToGameplayScene(LevelLoadingData levelLoadingData)
        {
            _levelDataLoader.Load(SceneID.QuizScene, levelLoadingData);
        }
    }
}