using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Credits
{
    internal class SummaryManager : MonoBehaviour
    {
        public TextMeshProUGUI summaryText;

        public void Start()
        {
            var targetsToHit = GameManager.Instance.targetsToHit.Aggregate("", (acc, curr) => acc + $"{curr} ");
            var targetsHit = GameManager.Instance.targetsHit.Aggregate("", (acc, curr) => acc + $"{curr} ");

            summaryText.text = $"Cele do trafienia: {targetsToHit}\nCele trafione: {targetsHit}";
        }

    }
}
