using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoresGenerales : MonoBehaviour
{
    [Header ("Array GameObjects"), Space]
    [SerializeField] private GameObject[] piezasExteriores;
    [SerializeField] private GameObject[] rines;
    [Header("Piezas Individuales"), Space]
    [SerializeField] private GameObject sillones;
    [SerializeField] private GameObject techo;
    private bool continuar;//para continuar con un proceso o con el otro
    private Color32 
        verde = new Color32(0, 105, 106, 255), 
        negro = new Color32(0, 0, 0, 255), 
        blanco = new Color32(255, 255, 255, 255),
        gris = new Color32(174, 174, 174, 255),
        rojo = new Color32(255, 0, 0, 255), 
        azul = new Color32(0, 128, 255, 255),
        dorado = new Color32(123, 101, 0, 255);//Asignación de colores a las variables Color32
    /// <summary>
    /// muestra el panel de autos prefabricados
    /// </summary>
    public void Perzonalizar()
    {
        if (!continuar)
        {
            continuar = true;
            GameObject.Find("Botón").GetComponent<animationButton>().BotonActivo("colores");
            GameObject.Find("Canvas").GetComponent<Colors>().Perzonalizar();
        }
        else
        {
            continuar = false;
            GameObject.Find("Botón").GetComponent<animationButton>().DesactivarTodos();
            GameObject.Find("Canvas").GetComponent<Colors>().Despersonalizar();
        }
    }
    /// <summary>
    /// asigna colores pertenecientes al prefab Negro
    /// </summary>
    public void Negro()
    {
        foreach (GameObject pieza in piezasExteriores)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", negro);
        }

        foreach (GameObject pieza in rines)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", dorado);
        }

        sillones.GetComponent<Renderer>().material.SetColor("_Color", gris);
        techo.GetComponent<Renderer>().material.SetColor("_Color", negro);
    }
    /// <summary>
    /// asigna colores pertenecientes al prefab Verde
    /// </summary>
    public void Verde()
    {
        foreach (GameObject pieza in piezasExteriores)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", verde);
        }

        foreach (GameObject pieza in rines)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", gris);
        }

        sillones.GetComponent<Renderer>().material.SetColor("_Color", negro);
        techo.GetComponent<Renderer>().material.SetColor("_Color", negro);
    }
    /// <summary>
    /// asigna colores pertenecientes al prefab Rojo
    /// </summary>
    public void Rojo()
    {
        foreach (GameObject pieza in piezasExteriores)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", rojo);
        }

        foreach (GameObject pieza in rines)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", gris);
        }

        sillones.GetComponent<Renderer>().material.SetColor("_Color", negro);
        techo.GetComponent<Renderer>().material.SetColor("_Color", negro);
    }

    /// <summary>
    /// asigna colores pertenecientes al prefab Blanco
    /// </summary>
    public void Blanco()
    {
        foreach (GameObject pieza in piezasExteriores)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", blanco);
        }

        foreach (GameObject pieza in rines)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", blanco);
        }

        sillones.GetComponent<Renderer>().material.SetColor("_Color", blanco);
        techo.GetComponent<Renderer>().material.SetColor("_Color", blanco);
    }
    /// <summary>
    /// asigna colores pertenecientes al prefab Gris
    /// </summary>
    public void Gris()
    {
        foreach (GameObject pieza in piezasExteriores)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", gris);
        }

        foreach (GameObject pieza in rines)
        {
            pieza.GetComponent<Renderer>().material.SetColor("_Color", negro);
        }

        sillones.GetComponent<Renderer>().material.SetColor("_Color", gris);
        techo.GetComponent<Renderer>().material.SetColor("_Color", negro);
    }
}
