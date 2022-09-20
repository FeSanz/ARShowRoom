using UnityEngine;

public class ColorOriginal : MonoBehaviour
{
    private Color MyColorOriginal;
    private float metalicidad;
    /// <summary>
    /// Al principio guarda el color original del GameObject, asimismo su metalicidad
    /// </summary>
    public void Awake()
    {
        MyColorOriginal = gameObject.gameObject.GetComponent<Renderer>().material.color;
        metalicidad = gameObject.gameObject.GetComponent<Renderer>().material.GetFloat("_Metallic");
    }
    /// <summary>
    /// Tomar el color original
    /// </summary>
    /// <returns>El color original del GameObject</returns>
    public Color GetColor()
    {
        return MyColorOriginal;
    }
    /// <summary>
    /// Tomar la metalicidad original
    /// </summary>
    /// <returns>La metalicidad original del GameObect</returns>
    public float GetMetallic()
    {
        return metalicidad;
    }
}
