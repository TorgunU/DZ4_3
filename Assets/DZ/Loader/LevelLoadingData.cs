namespace Assets.Patterns.DZ4_3
{
    public class LevelLoadingData
    {
        private QuizVictoryConditionType _quizVictoryConditionType;

        public LevelLoadingData(QuizVictoryConditionType quizVictoryConditionType)
        {
            _quizVictoryConditionType = quizVictoryConditionType;
        }

        public QuizVictoryConditionType QuizVictoryConditionType => _quizVictoryConditionType;
    }
}