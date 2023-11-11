using Assets.Patterns.DZ4_3;
using Zenject;
using System;

public class VictoryConditionInstaller : MonoInstaller
{
    private LevelLoadingData _levelLoadingData;

    [Inject]
    public void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
    }

    public override void InstallBindings()
    {
        InstallVictoryCondition();
        Container.BindInterfacesAndSelfTo<Level>().AsSingle().NonLazy();
    }

    private BallType GetRandomBallType()
    {
        BallType b = (BallType)UnityEngine.Random.Range(0, (Enum.GetValues(typeof(BallType)).Length));
        return b;
    }

    private void InstallOneTypeBurstCondition()
    {
        Container.Bind<BallType>().FromMethod(GetRandomBallType).AsSingle()
            .WhenInjectedInto<OneBallTypeVictoryCondition>();
        Container.BindInterfacesAndSelfTo<OneBallTypeVictoryCondition>().AsSingle();
    }

    private void InstallAllBurstCondition()
    {
        Container.BindInterfacesAndSelfTo<AllBallsTypeVictoryCondition>().AsSingle();
    }

    private void InstallVictoryCondition()
    {
        switch (_levelLoadingData.QuizVictoryConditionType)
        {
            case QuizVictoryConditionType.OneTypeBurst:
                InstallOneTypeBurstCondition();
                break;

            case QuizVictoryConditionType.AllBurst:
                InstallAllBurstCondition();
                break;

            default:
                throw new ArgumentException(nameof(_levelLoadingData.QuizVictoryConditionType));
        }
    }
}
