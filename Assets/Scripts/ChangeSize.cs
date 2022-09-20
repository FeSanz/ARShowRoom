using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSize : MonoBehaviour
{
    [Header("Botones"), Space]
    [SerializeField] private Button desk;
    [SerializeField] private Button medium;
    [SerializeField] private Button real;
    [SerializeField] private GameObject auto;
    private Color colorNormal = new Color(255, 255, 255);
    private Color colorActivo = new Color(0, 5, 12);

    /// <summary>
    /// Al comenzar se inicializan los OnClick + el botón activo
    /// </summary>
    private void Start()
    {
        real.onClick.AddListener(setRealSize);
        medium.onClick.AddListener(setMediumSize);
        desk.onClick.AddListener(setDeskSize);
        desk.GetComponent<Image>().color = colorActivo;
    }
    /// <summary>
    /// Muestra el acto a una escala normal, y muestra como activo el botón "real" cambiando su color
    /// </summary>
    private void setRealSize()
    {
        real.GetComponent<Image>().color = colorActivo;
        medium.GetComponent<Image>().color = colorNormal;
        desk.GetComponent<Image>().color = colorNormal;
        auto.transform.localScale = new Vector3(0.027f, 0.027f, 0.027f);
    }
    /// <summary>
    /// Muestra el acto a una escala mediana, y muestra como activo el botón "medium" cambiando su color
    /// </summary>
    private void setMediumSize()
    {
        real.GetComponent<Image>().color = colorNormal;
        medium.GetComponent<Image>().color = colorActivo;
        desk.GetComponent<Image>().color = colorNormal;
        auto.transform.localScale = new Vector3(0.013f, 0.013f, 0.013f);
    }
    /// <summary>
    /// Muestra el acto a una escala de escritorio, y muestra como activo el botón "desk" cambiando su color
    /// </summary>
    private void setDeskSize()
    {
        real.GetComponent<Image>().color = colorNormal;
        medium.GetComponent<Image>().color = colorNormal;
        desk.GetComponent<Image>().color = colorActivo;
        auto.transform.localScale = new Vector3(0.0028f, 0.0028f, 0.0028f);
    }

}
