using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Targets
{
    internal class TargetMoveSystem : MonoBehaviour
    {
        public TargetBehaviourController targetBehaviourController;
        public TargetVisualController visualController;
        public float stopDistance = 0.2f;


        public event Action OnDestinationAchieved;

        private NavMeshAgent agent;
        private bool destinationSet = false;

        private void OnDisable()
        {
            agent.isStopped = true;
        }

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        public void SetDestination(Vector3 destination)
        {
            agent.SetDestination(destination);
            destinationSet = true;
        }

        void Update()
        {
            //if (!agent.pathPending && agent.remainingDistance <= stopDistance)
            //{
            //    index = (index + 1) % waypoints.Length;
            //    agent.SetDestination(waypoints[index].position);
            //}


            bool isWalking =
                !agent.pathPending &&
                agent.remainingDistance > agent.stoppingDistance &&
                agent.velocity.sqrMagnitude > 0.01f;

            Debug.Log("isWalking: " + isWalking);

            if (isWalking)
                TurnTarget();

            visualController.SetIsWalking(isWalking);

            if (!agent.pathPending && destinationSet && agent.remainingDistance <= stopDistance)
            {
                Debug.Log("Destination: " + agent.destination);
                Debug.Log("Destination: " + agent.remainingDistance);

                OnDestinationAchieved?.Invoke();
            }
        }

        private void TurnTarget()
        {
            var direction = agent.destination - transform.position;

            if(direction.x < 0)
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
