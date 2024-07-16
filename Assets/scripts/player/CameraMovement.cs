using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Variables publicas
    public float rotationSpeed, yMinRotation, yMaxRotation;
    

    //Variables privadas
    private float yRotation;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Funcion para mover la camara
    public void CameraRotation()
    {
        //Verificamos si el cursor esta en alguno de los bordes de la pantalla
        //Derecha
        if (Input.mousePosition.x >= Screen.width * 0.95f)
        {
            yRotation += rotationSpeed * Time.deltaTime;
        }
        //Izquierda
        else if (Input.mousePosition.x <= Screen.width * 0.05f)
        {
            yRotation -= rotationSpeed * Time.deltaTime;
        }

        //Aplicamos el angulo de rotacion
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
