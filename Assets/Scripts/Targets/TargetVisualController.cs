using System;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class TargetVisualController : MonoBehaviour
    {
        public Animator animator;
        public Action OnAnimationBehaviourEnds;

        public void PlayAnimation(string animationName)
        {
            animator.Play(animationName);
        }

        public void PerformOnAnimationBehaviorEnds()
        {
            OnAnimationBehaviourEnds?.Invoke();
        }

        public void SetIsWalking(bool isWalking)
        {
            animator.SetBool("walk", isWalking);
        }
    }
}
