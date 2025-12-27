using System;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class TargetVisualController : MonoBehaviour
    {
        public Animator animator;
        public Action OnAnimationBehaviourEnds;
        public Action OnEscapePathAchieved;

        public void PlayAnimation(string animationName)
        {
            animator.Play(animationName);
        }

        public void PerformOnAnimationBehaviorEnds()
        {
            OnAnimationBehaviourEnds?.Invoke();
        }

        public void PerformOnEscapePathAchieved()
        {
            OnEscapePathAchieved?.Invoke();
        }

        public void SetIsWalking(bool isWalking)
        {
            animator.SetBool("walk", isWalking);
        }

        public void SetWalkSpeed(float speed)
        {
            animator.SetFloat("walk_speed", speed);

        }
    }
}
