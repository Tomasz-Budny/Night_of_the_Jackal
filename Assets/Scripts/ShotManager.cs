using Assets.Scripts.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class ShotManager : SingletonInstance<ShotManager>
    {
        public GraphicRaycaster shotAreaRaycaster;

        private bool shotFirstTime = false;

        public event Action OnShotFirstTime;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0) && !shotFirstTime)
            {
                PointerEventData data = new PointerEventData(EventSystem.current);
                data.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();

                if (shotAreaRaycaster != null) shotAreaRaycaster.Raycast(data, results);

                if(results.Count > 0 )
                {
                    shotFirstTime = true;
                    OnShotFirstTime?.Invoke();
                }
            }
        }
    }
}
