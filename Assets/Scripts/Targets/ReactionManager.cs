using Assets.Scripts.Architecture;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class ReactionManager : SingletonInstance<ReactionManager>
    {
        public Sprite heartEmoji;
        public Sprite angryEmoji;
        public Sprite meatEmoji;
        public Sprite wineEmoji;
        public Sprite phoneEmoji;
        public Sprite talkEmoji;
        public Sprite carrotEmoji;

        public Dictionary<string, Sprite> reactionEmojis;

        public void Start()
        {
            reactionEmojis = new Dictionary<string, Sprite>
            {
                { "heart", heartEmoji },
                { "anger", angryEmoji },
                { "food", meatEmoji },
                { "wine", wineEmoji },
                { "call", phoneEmoji },
                { "talk", talkEmoji },
                { "carrot", carrotEmoji }
            };
        }
    }
}
