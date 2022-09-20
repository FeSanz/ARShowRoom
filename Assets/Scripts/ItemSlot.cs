using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [Header("GameObjects"), Space]
    [SerializeField, Tooltip("La imagen que indica cuáles llantas están activas")] private GameObject marcador;
    [SerializeField, Tooltip("Los sprites diferentes de llantas")] private GameObject[] Llanta1;

    /// <summary>
    /// Para saber si un elemento fue arrastrado a su Render
    /// Al mismo tiempo el marcador lo pociciona en el lugar de origen de la imagen arrastrada
    /// </summary>
    /// <param name="eventData">este parámetro se obtiene en automático y son los datos del elemento arrastrado a este GameObject</param>
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = eventData.pointerDrag.GetComponent<DragYDrop>().positionOrigin;
            marcador.transform.position = new Vector2(eventData.pointerDrag.transform.position.x, marcador.transform.position.y);
            muestraLlantas(Int32.Parse(eventData.pointerDrag.name));
        }
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Activa las llantas pertenecientes al nombre de la imagen arrastrada
    /// en este caso es un numero el nombre
    /// </summary>
    /// <param name="num">es el nombre de la imagen arrastrada</param>
    public void muestraLlantas(int num)
    {
        foreach (GameObject llantas in Llanta1)
        {
            llantas.SetActive(false);
        }
        Llanta1[num].SetActive(true);
    }
}
