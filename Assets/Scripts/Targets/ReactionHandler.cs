using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Targets
{
    internal class ReactionHandler : MonoBehaviour
    {
        public GameObject reaction;
        public Image emojiImage;

        public void ShowReaction(string name)
        {
            emojiImage.sprite = ReactionManager.Instance.reactionEmojis[name];
            reaction.SetActive(true);
        }

        public void HideReaction()
        {
            reaction.SetActive(false);
        }
    }
}
