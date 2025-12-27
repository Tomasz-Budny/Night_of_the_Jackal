using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    [Serializable]
    public class TargetBehaviour
    {
        public Transform behaviourPosition;
        public string animationName;
        public float behaviourRotation;
    }

    internal class TargetBehaviourController : MonoBehaviour
    {
        public TargetSimpleMoveSystem moveSystem;
        public TargetVisualController visualController;

        public List<TargetBehaviour> targetBehaviours = new List<TargetBehaviour>();
        public bool mobileRoutines = true;

        private int _currentBehaviourIndex = 0;

        public void OnEnable()
        {
            moveSystem.OnDestinationAchieved += OnDestinationAchieved;
            visualController.OnAnimationBehaviourEnds += OnAnimationBehaviourEnds;
            ShotManager.Instance.OnShotFirstTime += OnHeardShot;
            visualController.OnEscapePathAchieved += OnEscaped;
        }

        public void OnDisable()
        {
            moveSystem.OnDestinationAchieved -= OnDestinationAchieved;
            visualController.OnAnimationBehaviourEnds -= OnAnimationBehaviourEnds;
            ShotManager.Instance.OnShotFirstTime -= OnHeardShot;
            visualController.OnEscapePathAchieved -= OnEscaped;
        }

        public void OnHeardShot()
        {
            visualController.PlayAnimation("idle");
            var nearestEscapeRoot = EscapeManager.Instance.GetNearestEscapePath(transform);
            targetBehaviours.Clear();
            targetBehaviours.Add(new TargetBehaviour
            {
                behaviourPosition = null,
                animationName = "escape",
                behaviourRotation = 0
            });

            _currentBehaviourIndex = 0;
            visualController.SetWalkSpeed(1.2f);
            moveSystem.speed = moveSystem.runSpeed;
            moveSystem.SetDestination(nearestEscapeRoot);
        }

        private void Start()
        {
            Debug.Log("moveSystem null: " + moveSystem == null);
            Debug.Log("targetBehaviours null: " + targetBehaviours == null);

            if(mobileRoutines)
                moveSystem.SetDestination(targetBehaviours[_currentBehaviourIndex].behaviourPosition.position);
        }

        private void OnEscaped()
        {
            TargetsManager.Instance.visibleTargetsCount--;
            Destroy(gameObject);
        }

        private void OnDestinationAchieved()
        {
            visualController.transform.rotation = Quaternion.Euler(0, targetBehaviours[_currentBehaviourIndex].behaviourRotation, 0);
            visualController.PlayAnimation(targetBehaviours[_currentBehaviourIndex].animationName);
        }

        private void OnAnimationBehaviourEnds()
        {
            NextBehaviour();
            moveSystem.SetDestination(targetBehaviours[_currentBehaviourIndex].behaviourPosition.position);

            //StartCoroutine(StartNextBehaviourCoroutine());
        }

        private IEnumerator StartNextBehaviourCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            NextBehaviour();
            moveSystem.SetDestination(targetBehaviours[_currentBehaviourIndex].behaviourPosition.position);
        }

        private void NextBehaviour()
        {
            _currentBehaviourIndex = (_currentBehaviourIndex + 1) % targetBehaviours.Count;
        }
    }
}
