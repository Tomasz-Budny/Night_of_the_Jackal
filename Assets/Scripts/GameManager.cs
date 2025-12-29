using Assets.Scripts.Architecture;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public Texture2D defaultCursor;

        public HashSet<string> avaialableTargets = new HashSet<string>()
        {
            "minimalist",
            "plutocrat",
            "oppositionist",
            "leader",
            "influencer",
            "artist",
            //"detective",
            //"engineer"
        };


        public string targetName;
        public GameResult gameResult;
        public float accuracy;

        public void Start()
        {
            SceneLoaderManager.Instance.LoadMenu();
            SetDefualtCursor();
        }

        public void SetDefualtCursor()
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        }

        public void DrawTargetsToHit()
        {
            targetsHit.Clear();
            targetsToHit.Clear();

            var avaialableTargetsCopy = new List<string>(avaialableTargets);

            var randomIndex = UnityEngine.Random.Range(0, avaialableTargetsCopy.Count);

            targetsToHit.Add(avaialableTargetsCopy[randomIndex]);

            avaialableTargetsCopy.RemoveAt(randomIndex);

            randomIndex = UnityEngine.Random.Range(0, avaialableTargetsCopy.Count);

            targetsToHit.Add(avaialableTargetsCopy[randomIndex]);
        }

        public void CalculateAccuracy()
        {
            var hitTargets = targetsHit.Aggregate("", (acc, curr) => acc + " " + curr);
            Debug.Log($"targets: {hitTargets} shots: {ShotManager.Instance.shotsCount}");

            accuracy = (float)targetsHit.Count / (float)ShotManager.Instance.shotsCount * 100f;
        }
    }
}
