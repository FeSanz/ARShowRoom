using UnityEngine;
using System.Collections;

public class drag : MonoBehaviour
{
    [SerializeField] private GameObject auto;
    float distance = 10;
    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, auto.transform.position.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
}