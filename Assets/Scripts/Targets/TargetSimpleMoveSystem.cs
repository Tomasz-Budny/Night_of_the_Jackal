using System;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Targets
{
    internal class TargetSimpleMoveSystem : MonoBehaviour
    {
        public float speed;
        public float runSpeed;
        public float stopDistance = 0.1f;
        public TargetVisualController visualController;

        public event Action OnDestinationAchieved;

        private Vector3 _currentDestination;
        private bool _destinationAchieved = false;

        public void SetDestination(Vector3 destination)
        {
            _currentDestination = destination;
            _destinationAchieved = false;
        }

        private void Update()
        {
            var direction = transform.position - _currentDestination;

            var remainingDistance = math.abs(transform.position.x - _currentDestination.x);

            if (remainingDistance < stopDistance && !_destinationAchieved)
            {
                visualController.SetIsWalking(false);
                _destinationAchieved = true;
                OnDestinationAchieved?.Invoke();
            }
            else
            {
                visualController.SetIsWalking(true);
                AlignRotation();
                transform.position = Vector3.MoveTowards(transform.position, _currentDestination, speed * Time.deltaTime);
            }
        }

        private void AlignRotation()
        {
            var direction = _currentDestination - transform.position;

            if (direction.x < 0)
            {
                visualController.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                visualController.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
