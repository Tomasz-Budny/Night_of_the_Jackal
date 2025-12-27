using Assets.Scripts;
using Assets.Scripts.Draggables;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    protected RectTransform rt;
    protected Canvas canvas;

    public virtual void Awake()
    {
        rt = (RectTransform)transform;
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null) Debug.LogError("Brak Canvas w parentach.");
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        // Opcjonalnie: przenieœ na wierzch, ¿eby nie chowa³o siê pod innymi
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
        
        var distanceFromCursor = GetDistanceFromCursor(eventData);

        var parent = rt.parent as RectTransform;
        if (parent == null) return;

        Vector2 min = parent.rect.min - rt.rect.min;
        Vector2 max = parent.rect.max - rt.rect.max;

        Vector2 p = rt.anchoredPosition;
        rt.anchoredPosition = new Vector2(
            Mathf.Clamp(p.x, min.x, max.x),
            Mathf.Clamp(p.y, min.y, max.y)
        );

        if (distanceFromCursor > DraggablesManager.Instance.distanceToSplit)
        {
            eventData.pointerDrag = null;
            eventData.dragging = false;
        }
    }

    private float GetDistanceFromCursor(PointerEventData eventData)
    {
        var camera = CameraManager.Instance.camera;
        var pivotScreen = RectTransformUtility.WorldToScreenPoint(camera, rt.position);

        Debug.Log("pivotScreen: " + pivotScreen);
        Debug.Log("eventData.position: " + eventData.position);

        var distance = Vector2.Distance(eventData.position, pivotScreen);

        return distance;
    }
}
