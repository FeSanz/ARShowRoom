using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMyColor : MonoBehaviour
{
    private GameObject paleta;//la paleta que contiene el script Colors
    private Color mycolor;//paar guardar el color que tiene
    /// <summary>
    /// busca el CanvasP para guardarlo en la variable paleta
    /// Se asigna el evento OnClick en este caso al método SetColor
    /// Esto para solo arrastrar el script al bot´n que tiene un color sin hacer otra cosa
    /// </summary>
    private void Start()
    {
        paleta = GameObject.FindGameObjectWithTag("CanvasP");
        gameObject.GetComponent<Button>().onClick.AddListener(SetColor);
        mycolor = gameObject.GetComponent<Image>().color;
    }
    /// <summary>
    /// Se manda el color al script Colors para cambiarlo a las piezas
    /// </summary>
    private void SetColor()
    {
        paleta.GetComponentInChildren<Colors>().GetColor(mycolor);
    }
}
