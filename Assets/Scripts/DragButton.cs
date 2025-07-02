using UnityEngine;
using UnityEngine.EventSystems;

public class DragButton : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float minDragDistance = 50f;
    private Vector2 initialTouchPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        initialTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float dragDistance = Vector2.Distance(eventData.position, initialTouchPosition);
        if (dragDistance >= minDragDistance)
        {
            // Se ha arrastrado lo suficiente, realizar la acción del botón
            PerformButtonAction();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reiniciar el estado si el dedo se levanta antes de arrastrar lo suficiente
        initialTouchPosition = Vector2.zero;
    }

    private void PerformButtonAction()
    {
        // Aquí puedes implementar la acción del botón cuando se arrastra lo suficiente
        Debug.Log("Se ha arrastrado lo suficiente. Realizar la acción del botón.");
    }
}
