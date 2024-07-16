using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
 //Funcion interaccion 
 public void Interaction()
    {
        //Si preciono el clic izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            //Creamos un rato desde la camara hacia la posciion del cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if(Physics.Raycast(ray, out _hit,100))
            {
                //Si el objeto tiene el objeto de interaccion
                if(_hit.transform.gameObject.GetComponent<InteracttableObject>() != null) {

                    _hit.transform.gameObject.GetComponent<InteracttableObject>().Interact();
                }
            }
        }
    }
}
