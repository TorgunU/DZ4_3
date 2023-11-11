namespace Assets.Patterns.DZ4_3
{
    public interface ISceneLoadMediator
    {
        void GoToChoseScene();
        void GoToGameplayScene(LevelLoadingData levelLoadingData);
    }
}