using Assets.Scripts.Architecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class CursorManager : SingletonInstance<CursorManager>
    {
        public Texture2D crosshairCursor;
        public Texture2D handCursor;
        public Vector2 handCursorHotspot;

        private bool _handCursorActive = false;

        public GraphicRaycaster shotAreaRaycaster;

        void Start()
        {
            Cursor.SetCursor(crosshairCursor, new Vector2(crosshairCursor.width / 2, crosshairCursor.height / 2), CursorMode.Auto);
        }

        bool IsPointerOverUI()
        {
            if (EventSystem.current == null) return false;
            return EventSystem.current.IsPointerOverGameObject();
        }

        private void Update()
        {
            //bool overUI = IsPointerOverUI();

            //if (overUI && !_handCursorActive)
            //{
            //    Cursor.SetCursor(handCursor, new Vector2(handCursor.width / 2, handCursor.height / 2), CursorMode.Auto);
            //    _handCursorActive = true;
            //}
            //else if (!overUI && _handCursorActive)
            //{
            //    Cursor.SetCursor(crosshairCursor, new Vector2(crosshairCursor.width / 2, crosshairCursor.height / 2), CursorMode.Auto);
            //    _handCursorActive = false;
            //}

            PointerEventData data = new PointerEventData(EventSystem.current);
            data.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            if(shotAreaRaycaster != null) shotAreaRaycaster.Raycast(data, results);

            if (results.Count > 0)
            {
                Cursor.SetCursor(crosshairCursor, new Vector2(crosshairCursor.width / 2, crosshairCursor.height / 2), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(handCursor, new Vector2(handCursor.width / 2, handCursor.height / 2), CursorMode.Auto);
            }
        }
    }
}
