using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Piezas"), Space]
    [SerializeField, Tooltip("GO de las puertas")] private GameObject puerta;
    [SerializeField, Tooltip("GO del cofre")] private GameObject cofre;

    private float AngleCofre = 0, AACofre = 0;//angulos iniciales del cofre
    private float AngleDoor = 0, AADoor = 0;//angulos iniciales de las puertas
    private bool puertasCon = false;//

    // Update is called once per frame
    //El GameObject sigue los angulos que tiene dicha variable, su velocidad varía entre el tiempo, eje y su ángulo
    private void Update()
    {
        AACofre = Mathf.LerpAngle(AACofre, AngleCofre, Time.deltaTime * 3f);
        cofre.transform.localEulerAngles = new Vector3(0, 0, AACofre);

        AADoor = Mathf.LerpAngle(AADoor, AngleDoor, Time.deltaTime * 3f);
        puerta.transform.localEulerAngles = new Vector3(0, 0, AADoor);
    }
    /// <summary>
    /// cambia el valor de AngleCofre
    /// </summary>
    public void OpenCofre()
    {
        AngleCofre = 40;
    }
    /// <summary>
    /// cambia el valor de AngleDoor
    /// </summary>
    public void OpenDoors()
    {
        AngleDoor = -60;
    }
    /// <summary>
    /// Comprueba la colision a la que ha entrado
    /// </summary>
    /// <param name="collision">variable que almacena los datos de dicha la colisión</param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "cofre")
        {
            OpenCofre();
        }
        if (collision.gameObject.tag == "puertasObj")
        {
            OpenDoors();
        }
    }
    /// <summary>
    /// cambia el valor a AngleCofre
    /// </summary>
    public void CloseCofre()
    {
        AngleCofre = 0;
    }
    /// <summary>
    /// cambia el valor a AngleDoor
    /// </summary>
    public void CloseDoors()
    {
        AngleDoor = 0;
    }
    /// <summary>
    /// Comprueba la colision a la que ha salido
    /// </summary>
    /// <param name="collision">variable que almacena los datos de dicha la colisión</param>
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "cofre")
        {
            CloseCofre();
        }

        if (collision.gameObject.tag == "puertasObj")
        {
            CloseDoors();
        }
    }
    /// <summary>
    /// abre las puertas y cofre si es que están cerrados, en otro caso los cierra
    /// </summary>
    public void puertas()
    {
        if (!puertasCon)
        {
            puertasCon = true;
            OpenCofre();
            OpenDoors();
            GameObject.Find("Botón").GetComponent<animationButton>().BotonActivo("puertas");
        }
        else
        {
            puertasCon = false;
            CloseCofre();
            CloseDoors();
            GameObject.Find("Botón").GetComponent<animationButton>().DesactivarTodos();
        }
    }
}
