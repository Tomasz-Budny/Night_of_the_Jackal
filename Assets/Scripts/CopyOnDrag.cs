using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    internal class CopyOnDrag : MonoBehaviour, IBeginDragHandler
    {
        private bool dragged = false;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(!dragged)
            {
                StickyNoteManager.Instance.CreateStickyNote();
                dragged = true;
            }
        }
    }
}
