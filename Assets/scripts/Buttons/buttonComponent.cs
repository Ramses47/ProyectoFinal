using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class buttonComponent : MonoBehaviour
{
    //Variables publicas
    public Material materialOff, materialOn, materialDisable;
    public UnityEvent OnActivated, OnDesactived;

    //Variables privadas
    private bool buttonState;
    private MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de variables
        buttonState = false;
        meshRenderer = GetComponent<MeshRenderer>();

        //Inicia apagado
        meshRenderer.material = materialOff;
    }

    public void Switch()
    {
        //Si el boton esta encendio
        if (buttonState)
        {
            //Se apaga
            buttonState = false;
            meshRenderer.material = materialOff;
            OnDesactived.Invoke();
        }
        else //Si el boton esta apagado
        {
            //Se prende
            buttonState = true;
            meshRenderer.material = materialOn;
            OnActivated.Invoke();
        }
    }
}
