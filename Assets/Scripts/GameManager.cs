using Assets.Scripts.Architecture;

namespace Assets.Scripts
{
    internal enum GameResult
    {
        Timeout,
        PlayerWon,
        WrongTargetHit
    }

    internal class GameManager : SingletonInstance<GameManager>
    {
        public string targetName;
        public GameResult gameResult;
    }
}
