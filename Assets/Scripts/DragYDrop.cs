using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragYDrop : MonoBehaviour, IDropHandler, IDragHandler
{
    [SerializeField, Tooltip("La imagen a la que será arrastrado")] private GameObject Image;
    private RectTransform rectTransform;
    public Vector2 positionOrigin;
    /// <summary>
    /// al comenzar se obtiene su RectTransform y posición actual
    /// </summary>
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        positionOrigin = gameObject.transform.position;
    }
    
    /// <summary>
    /// Cuando es tocado se puede arrastrar con este método
    /// Y se activa la imagen donde se va a arrastrar este gameobject
    /// </summary>
    /// <param name="eventData">se obtinen los datos de quien lo está arrastrando</param>
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Image.SetActive(true);
    }
    
    /// <summary>
    /// cuando se suelta se regresa a su posición original y se desactiva la imagen a la que se pretender arrastrar
    /// </summary>
    /// <param name="eventData">los datos de lo que lo arrastró</param>
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().position = positionOrigin;
        Image.SetActive(false);
    }
    
}
