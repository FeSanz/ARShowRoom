using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class IndicatorBehaviour : MonoBehaviour
{
    private MeshRenderer mesh = null;
    public static bool groundFound = false;
    [SerializeField] GameObject Found;
    [SerializeField] GameObject NotFound;
    void Start()
    {
        mesh = transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (mesh != null)
        {
            if (mesh.enabled == true)
            {
                Found.SetActive(true);
                NotFound.SetActive(false);
                groundFound = true;
            }
            else
            {
                Found.SetActive(false);
                NotFound.SetActive(true);
                groundFound = false;
            }
        }
        else
        {
            print("Error. Inicador no encontrado");
        }
    }
}
