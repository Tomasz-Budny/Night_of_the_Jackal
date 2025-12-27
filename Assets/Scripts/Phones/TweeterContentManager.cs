using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Phones
{
    internal class TweeterContentManager : MonoBehaviour
    {
        private ScrollRect _scrollView;

        public RectTransform plutocratContent;
        public RectTransform minimalistContent;
        public RectTransform oppositionistContent;
        public RectTransform leaderContent;
        public RectTransform influencerContent;
        public RectTransform artistContent;
        public RectTransform detectiveContent;
        public RectTransform engineerContent;


        private Dictionary<string, RectTransform> _targetToContentDict;

        private int activeTargetWallIndex = 0;

        private List<string> targetsToHit;

        public void Start()
        {
            _targetToContentDict = new Dictionary<string, RectTransform>()
            {
                { "plutocrat", plutocratContent },
                { "minimalist", minimalistContent },
                { "oppositionist", oppositionistContent },
                { "leader", leaderContent },
                { "influencer", influencerContent },
                { "artist", artistContent },
                { "detective", detectiveContent },
                { "engineer", engineerContent }
            };

            GameManager.Instance.DrawTargetsToHit();

            targetsToHit = GameManager.Instance.targetsToHit.ToList();

            _scrollView = GetComponent<ScrollRect>();
            _scrollView.content = _targetToContentDict[targetsToHit[activeTargetWallIndex]];
            _targetToContentDict[targetsToHit[activeTargetWallIndex]].gameObject.SetActive(true);
        }

        public void ToggleActiveFeed()
        {
            _targetToContentDict[targetsToHit[activeTargetWallIndex]].gameObject.SetActive(false);

            activeTargetWallIndex = ++activeTargetWallIndex % targetsToHit.Count();
            _scrollView.content = _targetToContentDict[targetsToHit[activeTargetWallIndex]];

            _targetToContentDict[targetsToHit[activeTargetWallIndex]].gameObject.SetActive(true);

        }
    }
}
