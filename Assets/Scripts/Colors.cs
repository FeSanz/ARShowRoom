using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Colors : MonoBehaviour
{
    [Header ("Paletas de colores"), Space]
    [SerializeField] private GameObject paletaColores;
    [SerializeField] private GameObject paletaColoresNormales;
    [SerializeField] private GameObject paletaColoresRines;
    [SerializeField] private GameObject panelLlantas;
    [SerializeField] private GameObject paletaPersonalizar;
    [SerializeField] private GameObject panelTransparencia;
    [Header("UI"), Space]
    [SerializeField] private GameObject butonEncender;
    [SerializeField] private TextMeshProUGUI nombreObjeto;
    [SerializeField] private Image colorActual;
    [SerializeField] private Slider transparencia;
    [Header("Motor"), Space]
    [SerializeField] private Animator motor;
    private Color ColorMaterial;
    private string tagger;
    private bool poder = true, contin = false, colorsCon, llantasCon;
    private List<GameObject> Piezas = new List<GameObject>();//array para guardar las piezas pertenecientes a la pieza seleccionada

    /// <summary>
    /// Contiene el código para comprobar si ha hecho clic en una pieza, comprueba si tiene tal etiqueta
    /// si se puede continuar, valida que muestre un panel y desactive el resto
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10, -1, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.tag == "encenderMotor")
                {
                    MuestraPaleta(hit.collider.name, butonEncender);
                }
            }
        }
        if (Input.GetMouseButtonDown(0) && poder)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10, -1, QueryTriggerInteraction.Ignore))
            {

                if (hit.collider.tag != null && !IsPointerOverUIObject())
                {
                    AsignaPiezas(hit.collider.tag);
                    colorActual.color = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                    ColorMaterial = hit.collider.gameObject.GetComponent<Renderer>().material.color;
                    //Llantas y rines
                    if (hit.collider.tag == "Rines" || hit.collider.tag == "Llantas")
                    {
                        llantasCon = false;
                        llantas();
                        GameObject.Find("Botón").GetComponent<Animator>().SetBool("activo", true);
                        GameObject.Find("Botón").GetComponent<Animator>().SetBool("llantas", true);
                        GameObject.Find("Botón").GetComponent<animationButton>().active = true;
                        panelLlantas.SetActive(true);
                        if (hit.collider.tag == "Rines")
                        {
                            MuestraPaleta(hit.collider.name, paletaColoresRines);
                        }
                        else
                        {
                            MuestraPaleta(hit.collider.name, null);
                        }
                    }
                    else if(hit.collider.tag == "Vidrios")
                    {
                        llantasCon = true;
                        llantas();
                        MuestraPaleta(hit.collider.name, panelTransparencia);
                        panelLlantas.SetActive(false);
                    }
                    else
                    {
                        llantasCon = true;
                        llantas();
                        panelLlantas.SetActive(false);
                        panelTransparencia.SetActive(false);
                        MuestraPaleta(hit.collider.name, paletaColoresNormales);
                    }

                }
                if (hit.collider.tag == null)
                {
                    MuestraPaleta(hit.collider.name, null);
                }

                if (hit.collider.tag == "encenderMotor")
                {
                    MuestraPaleta(hit.collider.name, butonEncender);
                }

            }
        }
    }

    /// <summary>
    /// Para encender el motor del auto, y se liga a las animaciones que este contiene
    /// </summary>
    public void encender()
    {
        if (!contin)
        {
            motor.SetInteger("paso", 1);
            contin = true;
        }
        else
        {
            motor.SetInteger("paso", 0);
            contin = false;
        }
    }

    /// <summary>
    /// Para comprobar que se ha tocado un objeto de llantas y/o rines para mostrar su respectivo panel
    /// </summary>
    public void llantas()
    {
        if (!llantasCon)
        {
            llantasCon = true;
            //poder = false;
            panelLlantas.SetActive(true);
            AsignaPiezas("Rines");
            tagger = "Rines";
            GameObject.Find("Botón").GetComponent<Animator>().SetBool("llantas", true);
            colorActual.color = GameObject.FindGameObjectWithTag("Rines").GetComponent<Renderer>().material.color;
            ColorMaterial = GameObject.FindGameObjectWithTag("Rines").GetComponent<Renderer>().material.color;
            //panelLlantas.SetActive(true);
            MuestraPaleta("Rines", paletaColoresRines);
            GameObject.Find("Botón").GetComponent<animationButton>().BotonActivo("llantas");
        }
        else
        {
            llantasCon = false;
            panelLlantas.SetActive(false);
            paletaColores.SetActive(false);
            GameObject.Find("Botón").GetComponent<animationButton>().active = false;
            GameObject.Find("Botón").GetComponent<Animator>().SetBool("activo", false);
            GameObject.Find("Botón").GetComponent<Animator>().SetBool("llantas", false);
            GameObject.Find("Botón").GetComponent<animationButton>().DesactivarTodos();
        }
    }
    /// <summary>
    /// Para mostrar la transparencia de los cristales
    /// Del lado de la interfaz está un método que si ha cambiado el valor del Slider entonces se imboca este método
    /// </summary>
    public void changeTransparency()
    {
        float transp = transparencia.value;
        ColorMaterial.a = transp;
        GetColor(ColorMaterial);
    }

    /// <summary>
    /// Se hace una búsqueda de piezas que tengan la misma etiqueta dada por el rayo que ha colicionado en la pieza
    /// </summary>
    /// <param name="tag">es la etiqueta con la que colisionó el rayo</param>
    private void AsignaPiezas(string tag)
    {
        Piezas.Clear();
        Piezas = new List<GameObject>();
        foreach (GameObject pieza in GetAllObjectsOnlyInScene(tag))
        {
            Piezas.Add(pieza);
        }
    }
    /// <summary>
    /// Método para buscar elementos que no están visibles en la interfaz, realizando validaciones de lectura
    /// </summary>
    /// <param name="tag">la etiqueta a buscar en los elementos visibles y no visibles</param>
    /// <returns></returns>
    private List<GameObject> GetAllObjectsOnlyInScene(string tag)
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (/*!EditorUtility.IsPersistent(go.transform.root.gameObject) && */!(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            {
                if (go.tag == tag)
                {
                    objectsInScene.Add(go);
                }
                if (go.tag == "Rines")
                    go.GetComponent<ColorOriginal>().Awake();
            }
        }

        return objectsInScene;
    }
    /// <summary>
    /// Sirve para desactivar todos los paneles
    /// </summary>
    /// <param name="objeto">es el nombre de la paleta para mostrtarla</param>
    /// <param name="paleta">es el panel que será activado</param>
    private void MuestraPaleta(string objeto, GameObject paleta)
    {
        nombreObjeto.SetText(objeto);
        paletaColores.SetActive(true);
        paletaColoresRines.SetActive(false);
        paletaColoresNormales.SetActive(false);
        panelTransparencia.SetActive(false);
        butonEncender.SetActive(false);

        if (paleta != null)
        {
            paleta.SetActive(true);
        }
        else
        {
            paletaColores.SetActive(false);
        }
    }

    /// <summary>
    /// comprueba el color de la pieza y asimismo lo asigna a un componente tipo Image
    /// </summary>
    /// <param name="colorP">Se obtiene el color de la pieza que se ha tocado</param>
    public void GetColor(Color colorP)
    {
        if (tagger == "Vidrios")
        {
            colorP.a = transparencia.value;
            foreach (GameObject pieza in Piezas)
            {
                pieza.GetComponent<Renderer>().material.SetColor("_Color", colorP);
            }
        }
        else
        {
            foreach (GameObject pieza in Piezas)
            {
                pieza.GetComponent<Renderer>().material.SetColor("_Color", colorP);
            }
        }
        colorActual.color = Piezas[0].GetComponent<Renderer>().material.color;
        colorActual.color = GameObject.FindGameObjectWithTag(tagger).GetComponent<Renderer>().material.color;
        ColorMaterial = Piezas[0].GetComponent<Renderer>().material.color;
    }

    /// <summary>
    /// Se hace un recorrido de todos los componentes e invoca su clase ColorOriginal  para restablecer el color default
    /// </summary>
    private void RestablecerColor()
    {
        foreach (GameObject pieza in Piezas)
        {
            Color original = pieza.GetComponent<ColorOriginal>().GetColor();
            //colorActual.color = original;
            transparencia.value = original.a;
            pieza.GetComponent<Renderer>().material.SetColor("_Color", original);
        }
        colorActual.color = Piezas[0].GetComponent<Renderer>().material.color;
    }
    /// <summary>
    /// Comprueba el clic en el espacio, si este es un componente de UI entonces es ignorado el rayo.
    /// </summary>
    /// <returns></returns>
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    /// <summary>
    /// se hace el cambio del valor de la variable Poder para saber si se puede 
    /// </summary>
    /// <param name="can"></param>
    public void Poder(bool can)
    {
        poder = can;

        if (!can)
        {
            panelLlantas.SetActive(false);
            panelTransparencia.SetActive(false);
            paletaColores.SetActive(false);
            paletaColoresNormales.SetActive(false);
            paletaColoresRines.SetActive(false);
        }
    }

    /// <summary>
    /// Muestra el la paleta de prefabricados haciendo las validaciones de desactivar el resto
    /// </summary>
    public void Perzonalizar()
    {
        MuestraPaleta(null, null);
        poder = false;
        paletaPersonalizar.SetActive(true);
    }
    /// <summary>
    /// Oculta la paleta de prefabricados
    /// </summary>
    public void Despersonalizar()
    {
        poder = true;
        paletaPersonalizar.SetActive(false);
    }
}
