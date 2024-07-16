using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteracttableObject : MonoBehaviour
{
    //Variables publica
    public UnityEvent OnInteractive;

    //Funcion intereaccion
    public void Interact()
    {
        //Activar evento 
        OnInteractive.Invoke();
    }
}
