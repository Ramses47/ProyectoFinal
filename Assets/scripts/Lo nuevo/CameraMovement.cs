using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables publicas
    public float rotationSpeed;
    public float yMinRotation;
    public float yMaxRotation;

    // Variables privadas
    private float yRotation;

    // Funcion para mover la camara
    public void CameraRotation()
    {
        // Verificamos si el cursor esta en alguno de los bordes de la pantalla
        if (Input.mousePosition.x >= Screen.width * 0.95f)
        {
            yRotation += rotationSpeed * Time.deltaTime;
        }
        else if (Input.mousePosition.x <= Screen.width * 0.05f)
        {
            yRotation -= rotationSpeed * Time.deltaTime;
        }

        // Aplicamos el angulo de rotacion
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

}
