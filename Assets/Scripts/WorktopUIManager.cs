using Assets.Scripts.Architecture;
using UnityEngine;

namespace Assets.Scripts
{
    internal class WorktopUIManager : SingletonInstance<WorktopUIManager>
    {
        private Canvas _canvas;

        private void Start()
        {
            _canvas = GetComponent<Canvas>();

            _canvas.worldCamera = CameraManager.Instance.camera;
        }
    }
}
