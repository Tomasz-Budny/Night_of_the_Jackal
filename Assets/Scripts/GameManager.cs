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
        public HashSet<string> targetsHit = new HashSet<string>();
        public HashSet<string> targetsToHit = new HashSet<string>();

        public HashSet<string> avaialableTargets = new HashSet<string>()
        {
            "minimalist",
            "plutocrat",
            "oppositionist",
            "lider",
            "influencer",
            "artist",
            "detective",
            "engineer"
        };


        public string targetName;
        public GameResult gameResult;

        public void DrawTargetsToHit()
        {
            var avaialableTargetsCopy = new List<string>(avaialableTargets);

            var randomIndex = UnityEngine.Random.Range(0, avaialableTargetsCopy.Count);

            targetsToHit.Add(avaialableTargetsCopy[randomIndex]);

            avaialableTargetsCopy.RemoveAt(randomIndex);

            randomIndex = UnityEngine.Random.Range(0, avaialableTargetsCopy.Count);

            targetsToHit.Add(avaialableTargetsCopy[randomIndex]);
        }


    }
}
