using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerSelect : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength, layermask)){
                Debug.Log(hit.collider.name);
            }
        }
    }
}
