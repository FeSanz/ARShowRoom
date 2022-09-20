using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationButton : MonoBehaviour
{
    [Header("Animator"), Space]
    [SerializeField, Tooltip("Button con el animator")] private Animator animButton;

    [Header("Botones"), Space]
    [SerializeField] private Button puertas;
    [SerializeField] private Button colores;
    [SerializeField] private Button llantas;
    [SerializeField] private Button chassis;
    private Color colorOriginal = new Color(1, 1, 1);
    private Color colorActivo = new Color32(82, 177, 255, 255);
    public bool active = false; //vaeriable para activar o desactivar el estado del botón, es publica porque desde otra clase puede ser activada o desactivada
    

    /// <summary>
    /// Para ejecutar 2 acciones, 1 al no estar activo y la otra estando activo
    /// </summary>
    public void activar()
    {
        if (!active)
        {
            animButton.SetBool("activo",true);
            active = true;
        }
        else
        {
            animButton.SetBool("activo", false);
            active = false;
        }
    }

    /// <summary>
    /// Para mostrar el botón activo cambiando el color del Image
    /// </summary>
    /// <param name="but">Contiene el nombre del botón a estar activo</param>
    public void BotonActivo(string but)
    {
        puertas.GetComponent<Image>().color = colorOriginal;
        puertas.interactable = false;
        colores.GetComponent<Image>().color = colorOriginal;
        colores.interactable = false;
        llantas.GetComponent<Image>().color = colorOriginal;
        llantas.interactable = false;
        chassis.GetComponent<Image>().color = colorOriginal;
        chassis.interactable = false;

        switch (but)
        {
            case "llantas":
                llantas.GetComponent<Image>().color = colorActivo;
                llantas.interactable = true;
                break;

            case "puertas":
                puertas.GetComponent<Image>().color = colorActivo;
                puertas.interactable = true;
                break;

            case "chassis":
                chassis.GetComponent<Image>().color = colorActivo;
                chassis.interactable = true;
                break;

            case "colores":
                colores.GetComponent<Image>().color = colorActivo;
                colores.interactable = true;
                break;

        }
    }
    /// <summary>
    /// Muestra todos estos botones como inactivos
    /// </summary>
    public void DesactivarTodos()
    {
        puertas.GetComponent<Image>().color = colorOriginal;
        puertas.interactable = true;
        colores.GetComponent<Image>().color = colorOriginal;
        colores.interactable = true;
        llantas.GetComponent<Image>().color = colorOriginal;
        llantas.interactable = true;
        chassis.GetComponent<Image>().color = colorOriginal;
        chassis.interactable = true;
    }
}
