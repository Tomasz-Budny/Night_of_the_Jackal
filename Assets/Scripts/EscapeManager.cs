using Assets.Scripts.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EscapeManager : SingletonInstance<EscapeManager>
    {
        public List<Transform> escapePaths;

        public Vector3 GetNearestEscapePath(Transform initialPosition)
        {
            var nearestPathPosition = Vector3.positiveInfinity;

            foreach (var path in escapePaths)
            {
                if (Vector3.Distance(initialPosition.position, path.position) <
                    Vector3.Distance(initialPosition.position, nearestPathPosition))
                {
                    nearestPathPosition = path.position;
                }
            }

            return nearestPathPosition;
        }
    }
}
