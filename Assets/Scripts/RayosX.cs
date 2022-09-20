using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayosX : MonoBehaviour
{
    [Header("Piezaa"), Space]
    [SerializeField, Tooltip("Objeros que serán trasparentados")] private GameObject[] Objetos;
    [Header("Shader"), Space]
    [SerializeField, Tooltip("Shader que aplica la transparencia en RM")] private Shader shaderTransparente;
    private Shader[] shaders;
    private float transparencia = 0.01f;
    private bool continuar = false;
    private int i = 0;
    private float segundosDw = 0, segundosUp = 0;

    /// <summary>
    /// al principio se toman los shaders iniciales de cada pieza
    /// </summary>
    private void Start()
    {
        shaders = new Shader[Objetos.Length+1];
        foreach (GameObject obj in Objetos)
        {
            i++;
            shaders[i] = obj.GetComponent<MeshRenderer>().material.shader;
            //shaders[i] = Objetos[i].GetComponent<Shader>();
        }
    }

    /// <summary>
    /// cuando la variable de segundos es mayor a 1 comienza a bajar hasta llegar a 0.1
    /// entonces simula un degradado en las piezas
    /// también quita la metalicidad de cada objeto porque si no se verá transparente y muy luminoso
    /// </summary>
    private void Update()
    {
        //Degradar
        if (segundosDw > 0.1)
        {
            //print("time: " + segundosDw);
            segundosDw = segundosDw - Time.deltaTime;
            foreach (GameObject obj in Objetos)
            {
                Color color = new Color(obj.GetComponent<MeshRenderer>().material.color.r, obj.GetComponent<MeshRenderer>().material.color.g, obj.GetComponent<MeshRenderer>().material.color.b);
                color.a = segundosDw;
                obj.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 0.08f);
                obj.GetComponent<MeshRenderer>().material.shader = shaderTransparente;
                obj.GetComponent<MeshRenderer>().material.color = color;
            }
        }
    }

    /// <summary>
    /// se activa o se desactiva el botón y muestra su respectiva animación
    /// cambia la variebla según su estado
    /// 
    /// </summary>
    public void rayosEquis()
    {
        if (!continuar)
        {
            GameObject.Find("Canvas").GetComponent<Colors>().Poder(false);
            GameObject.Find("Botón").GetComponent<animationButton>().BotonActivo("chassis");
            continuar = true;
            segundosDw = 1;
            GameObject.FindGameObjectWithTag("motor").GetComponent<Animator>().SetInteger("paso", 1);
        }
        else
        {
            GameObject.FindGameObjectWithTag("motor").GetComponent<Animator>().SetInteger("paso", 0);
            continuar = false;
            int j = 0;
            foreach (GameObject obj in Objetos)
            {
                j++;
                obj.GetComponent<MeshRenderer>().material.shader = shaders[j];
                //print("float  :" + obj.GetComponentInChildren<ColorOriginal>().GetMetallic());
                obj.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", obj.GetComponentInChildren<ColorOriginal>().GetMetallic());
                obj.GetComponent<MeshRenderer>().material.color = obj.GetComponentInChildren<ColorOriginal>().GetColor();
            }
            GameObject.Find("Canvas").GetComponent<Colors>().Poder(true);
            GameObject.Find("Botón").GetComponent<animationButton>().DesactivarTodos();
        }
    }
}
