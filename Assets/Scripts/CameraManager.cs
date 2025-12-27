using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    internal class CameraManager : SingletonInstance<CameraManager>
    {
        public Camera camera;
    }
}
