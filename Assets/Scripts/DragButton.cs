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
            // Se ha arrastrado lo suficiente, realizar la acci�n del bot�n
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
        // Aqu� puedes implementar la acci�n del bot�n cuando se arrastra lo suficiente
        Debug.Log("Se ha arrastrado lo suficiente. Realizar la acci�n del bot�n.");
    }
}
