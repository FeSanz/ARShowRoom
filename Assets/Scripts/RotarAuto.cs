using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotarAuto : MonoBehaviour
{   
    [SerializeField, Tooltip("Toogle para rotar o no el auto")] private Toggle rotar;
    [SerializeField, Tooltip("El auto completo")] private GameObject auto;
    private float speedRotation = 25;//velocidad de rotación

    /// <summary>
    /// si está activo el Toogle entonces rota el auto en su eje Y
    /// </summary>
    private void Update()
    {
        if (rotar.isOn)
        {
            auto.transform.RotateAround(auto.transform.position, Vector3.down, speedRotation * Time.deltaTime);
        }
    }
}
