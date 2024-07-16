using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CameraMovement camaraMovement;
    private Interactor interactor;

    // Start is called before the first frame update
    void Start()
    {
        camaraMovement = GetComponent<CameraMovement>();
        interactor = GetComponent<Interactor>();
    }

    // Update is called once per frame
    void Update()
    {
        camaraMovement.CameraRotation();
        interactor.Interaction();
    }
}
