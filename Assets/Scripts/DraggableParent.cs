using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    internal class DraggableParent : Draggable
    {
        public RectTransform parentTransform;

        public override void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
            rt = parentTransform;
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            base.OnBeginDrag(eventData);
            parentTransform.transform.SetAsLastSibling();
        }
    }
}
