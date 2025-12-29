using System;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Credits
{
    internal class SummaryManager : MonoBehaviour
    {
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI accuracyText;
        public TextMeshProUGUI victimsText;
        public TextMeshProUGUI targetsText;
        public TextMeshProUGUI gradeText;

        public float freeTime = 90;


        public void Start()
        {
            GameManager.Instance.SetDefualtCursor();

            var t = TimeSpan.FromSeconds(TimerManager.Instance.ellapsedTime);

            string result = t.ToString(@"m\:ss");

            timeText.text = $"{(int)t.TotalMinutes}:{t.Seconds:00}";
            accuracyText.text = $"{Math.Round(GameManager.Instance.accuracy)}%";

            var victims = GameManager.Instance.targetsHit.ToHashSet();
            victims.ExceptWith(GameManager.Instance.targetsToHit);

            var victimsCount = victims.Count;
            victimsText.text = $"{victimsCount}";

            var targets = GameManager.Instance.targetsHit.ToHashSet();
            targets.IntersectWith(GameManager.Instance.targetsToHit);

            targetsText.text = $"{targets.Count} / 2";

            gradeText.text = CalculateGrade(TimerManager.Instance.ellapsedTime, victimsCount, targets.Count, GameManager.Instance.accuracy);
        }

        public string CalculateGrade(float ellapsedTime, int victimsCount, int targetsHit, float accuracy)
        {
            var baseScore = 100f;

            baseScore = baseScore - (2- targetsHit) * 50f;
            baseScore = baseScore - victimsCount * 20f;
           
            if(ellapsedTime > freeTime)
            {
                baseScore = baseScore - (ellapsedTime - freeTime) * 0.5f;
            }

            baseScore = baseScore * (accuracy/100);

            if (baseScore >= 95f)
            {
                return "S";
            }
            else if (baseScore >= 80f)
            {
                return "A";
            }
            else if (baseScore >= 60f)
            {
                return "B";
            }
            else if (baseScore >= 40f)
            {
                return "C";
            }
            else if (baseScore >= 20f)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        public void Restart()
        {
            SceneLoaderManager.Instance.RestartGame();
        }
    }
}
