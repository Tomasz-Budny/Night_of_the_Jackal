using Assets.Scripts.Architecture;
using System.Collections.Generic;

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
        public HashSet<string> targetsShot = new HashSet<string>();

        public string targetName;
        public GameResult gameResult;
    }
}
